using MVPLib;
using MVPLib.Models;
using MVPLib.Presenters;
using MVPLib.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace GUIApp
{
    public partial class FootballForm : Form, IFootballView
    {
        private FootballPresenter presenter;
        private League selectedLeague;
        private Team selectedTeam;
        private Player selectedPlayer;
        private Dictionary<string, Dictionary<string, List<string>>> leagueTeamsPlayers;

        public FootballForm()
        {
            InitializeComponent();
            FakeFootballModel model = new FakeFootballModel();
            presenter = new FootballPresenter(this, model);
            leagueTeamsPlayers = new Dictionary<string, Dictionary<string, List<string>>>();

            model.DataChangedLeagues += () => ShowAllLeagues(model.GetLeagues());
            model.DataChangedTeams += () => UpdateTeamsAndPlayers();
            model.DataChangedPlayers += () => UpdateTeamsAndPlayers();

            comboBoxLeague.SelectedIndexChanged += ComboBoxLeague_SelectedIndexChanged;
            listBoxCom.SelectedIndexChanged += ListBoxCom_SelectedIndexChanged;
            listBoxPlayer.SelectedIndexChanged += ListBoxPlayer_SelectedIndexChanged;

            SaveForm.Click += SaveForm_Click;
            LoadForm.Click += LoadForm_Click;
        }

        private void LoadForm_Click(object sender, EventArgs e)
        {
            LoadDataFromJson();
        }

        private void SaveForm_Click(object sender, EventArgs e)
        {
            SaveDataToJson();
        }

        private void SaveDataToJson()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    // Example of populating leagueTeamsPlayers
                    leagueTeamsPlayers = PopulateLeagueTeamsPlayers(); // Ensure this method correctly populates your data

                    if (leagueTeamsPlayers.Count > 0)
                    {
                        string jsonData = JsonConvert.SerializeObject(leagueTeamsPlayers, Formatting.Indented);
                        File.WriteAllText(filePath, jsonData);
                        MessageBox.Show("Данные успешно сохранены в файл: " + filePath, "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Нет данных для сохранения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Dictionary<string, Dictionary<string, List<string>>> PopulateLeagueTeamsPlayers()
        {
            Dictionary<string, Dictionary<string, List<string>>> data = new Dictionary<string, Dictionary<string, List<string>>>();

            // Получаем список лиг из модели
            List<string> leagueNames = presenter.GetModel().GetLeagues();

            foreach (var leagueName in leagueNames)
            {
                var league = presenter.GetModel().GetLeagueByName(leagueName);
                if (league != null)
                {
                    Dictionary<string, List<string>> leagueData = new Dictionary<string, List<string>>();

                    // Получаем список команд для текущей лиги
                    List<string> teamNames = presenter.GetModel().GetTeams(leagueName);

                    foreach (var teamName in teamNames)
                    {
                        var team = league.Teams.FirstOrDefault(t => t.Name == teamName);
                        if (team != null)
                        {
                            List<string> playerNames = new List<string>();

                            // Получаем список игроков для текущей команды
                            foreach (var player in team.Players)
                            {
                                playerNames.Add(player.Name);
                            }

                            leagueData.Add(teamName, playerNames);
                        }
                    }

                    data.Add(leagueName, leagueData);
                }
            }

            return data;
        }


        private void UpdateFormData()
        {
            comboBoxLeague.Items.Clear();
            listBoxCom.Items.Clear();
            listBoxPlayer.Items.Clear();

            if (leagueTeamsPlayers != null)
            {
                foreach (string league in leagueTeamsPlayers.Keys)
                {
                    comboBoxLeague.Items.Add(league);
                }

                if (comboBoxLeague.Items.Count > 0)
                {
                    comboBoxLeague.SelectedIndex = 0;
                }
            }
        }


        private void LoadDataFromJson()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                if (File.Exists(filePath))
                {
                    try
                    {
                        string jsonData = File.ReadAllText(filePath);
                        leagueTeamsPlayers = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, List<string>>>>(jsonData);
                        UpdateFormData();
                        MessageBox.Show("Данные успешно загружены из файла: " + filePath, "Загрузка данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Выбранный файл не существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void ListBoxPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPlayer.SelectedItem != null)
            {
                string selectedPlayerName = listBoxPlayer.SelectedItem.ToString();
                selectedPlayer = selectedTeam.Players.FirstOrDefault(p => p.Name == selectedPlayerName);
            }
        }

        private void ListBoxCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCom.SelectedItem != null)
            {
                string selectedTeamName = listBoxCom.SelectedItem.ToString();
                selectedTeam = selectedLeague.GetTeamByName(selectedTeamName);
                TeamSelected?.Invoke(selectedTeam);
                updatePlayer(selectedTeam);
            }
        }

        private void ComboBoxLeague_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLeague.SelectedItem != null)
            {
                string selectedLeagueName = comboBoxLeague.SelectedItem.ToString();
                selectedLeague = presenter.GetModel().GetLeagueByName(selectedLeagueName);
                LeagueSelected?.Invoke(selectedLeague);
                UpdateTeamsAndPlayers();
            }
        }

        public event Action<League> LeagueSelected;
        public event Action<Team> TeamSelected;
        public event Action<League> AddLeague;
        public event Action<Team> AddTeam;
        public event Action<Player> AddPlayer;
        public event ViewDelegateLeague EditLeague;
        public event ViewDelegateTeam EditTeam;
        public event ViewDelegatePlayer EditPlayer;
        public event ViewDelegateTeam DeleteTeam;
        public event ViewDelegatePlayer DeletePlayer;

        public void ShowAllLeagues(List<string> leagues)
        {
            comboBoxLeague.Items.Clear();
            foreach (var league in leagues)
            {
                if (!comboBoxLeague.Items.Contains(league))
                {
                    comboBoxLeague.Items.Add(league);
                }
            }
        }

        public League GetSelectedLeague()
        {
            return selectedLeague;
        }

        public Team GetSelectedTeam()
        {
            return selectedTeam;
        }

        public void updateLeague(League l)
        {
            ShowAllLeagues(presenter.GetModel().GetLeagues());
        }

        public void updateTeam(League l)
        {
            listBoxCom.Items.Clear();
            foreach (var team in l.Teams)
            {
                if (!listBoxCom.Items.Contains(team.Name))
                {
                    listBoxCom.Items.Add(team.Name);
                }
            }
        }

        public void updatePlayer(Team t)
        {
            listBoxPlayer.Items.Clear();
            foreach (var player in t.Players)
            {
                listBoxPlayer.Items.Add(player.Name);
            }
        }

        private void inputLeague_Click(object sender, EventArgs e)
        {
            League newLeague = new League(textLeague.Text);
            AddLeague?.Invoke(newLeague);
            textLeague.Clear();
        }

        private void inputCom_Click(object sender, EventArgs e)
        {
            if (selectedLeague != null)
            {
                Team newTeam = new Team(textCom.Text);
                selectedLeague.AddTeam(newTeam);
                AddTeam?.Invoke(newTeam);
                textCom.Clear();

                UpdateTeamsAndPlayers();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите лигу.");
            }
        }

        private void inputPlayer_Click(object sender, EventArgs e)
        {
            if (selectedTeam != null)
            {
                Player newPlayer = new Player(textPlayer.Text);
                selectedTeam.AddPlayer(newPlayer);
                AddPlayer?.Invoke(newPlayer);
                textPlayer.Clear();

                updatePlayer(selectedTeam);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите команду.");
            }
        }

        private void deleteCom_Click(object sender, EventArgs e)
        {
            if (listBoxCom.SelectedItem != null)
            {
                Team team = selectedTeam;
                League league = selectedLeague;

                DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить команду \"{team.Name}\" из лиги \"{league.Name}\"?",
                                                      "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DeleteTeam?.Invoke(team, Name);
                }
            }
        }

        private void deletePlayer_Click(object sender, EventArgs e)
        {
            if (listBoxPlayer.SelectedItem != null)
            {
                Player player = new Player(listBoxPlayer.SelectedItem.ToString());
                Team team = selectedTeam;

                DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить игрока \"{player.Name}\" из команды \"{team.Name}\"?",
                                                      "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DeletePlayer?.Invoke(player, Name);
                }
            }
        }

        private void UpdateTeamsAndPlayers()
        {
            if (selectedLeague != null)
            {
                updateTeam(selectedLeague);
                if (selectedTeam != null)
                {
                    updatePlayer(selectedTeam);
                }
            }
        }

        private void editLeague_Click(object sender, EventArgs e)
        {
            if (selectedLeague != null)
            {
                string newName = ShowInputDialog("Введите новое название лиги:", "Изменение названия лиги");
                if (!string.IsNullOrEmpty(newName))
                {
                    DialogResult result = MessageBox.Show($"Вы уверены, что хотите изменить название лиги на \"{newName}\"?", "Подтверждение изменения", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        EditLeague?.Invoke(selectedLeague, newName);
                    }
                }
            }
        }

        private void editCom_Click(object sender, EventArgs e)
        {
            if (selectedTeam != null)
            {
                string newName = ShowInputDialog("Введите новое название команды:", "Изменение названия команды");
                if (!string.IsNullOrEmpty(newName))
                {
                    DialogResult result = MessageBox.Show($"Вы уверены, что хотите изменить название команды на \"{newName}\"?", "Подтверждение изменения", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        EditTeam?.Invoke(selectedTeam, newName);
                    }
                }
            }
        }

        private void editPlayer_Click(object sender, EventArgs e)
        {
            if (selectedPlayer != null)
            {
                string newName = ShowInputDialog("Введите новое имя игрока:", "Изменение имени игрока");
                if (!string.IsNullOrEmpty(newName))
                {
                    DialogResult result = MessageBox.Show($"Вы уверены, что хотите изменить имя игрока на \"{newName}\"?", "Подтверждение изменения", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        EditPlayer?.Invoke(selectedPlayer, newName);
                    }
                }
            }
        }
    }
}