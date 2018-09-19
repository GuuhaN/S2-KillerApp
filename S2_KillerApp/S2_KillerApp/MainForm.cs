using System.Windows.Forms;
using KillerApp_Library.Controllers;

namespace S2_KillerApp
{
    public partial class MainForm : Form
    {
        private readonly KillerApp_Library.Core.Music_Player musicPlayer = new KillerApp_Library.Core.Music_Player();

        public MainForm()
        {
            InitializeComponent();
            this.FormClosed += MainForm_FormClosed;
            btn_Play.Text = musicPlayer.isPaused ? @"▶" : @"❚❚";
            musicPlayer.Play("");
            MessageBox.Show(UserController.GetInstance().User.GetUserId().ToString());
            LoadPlaylists();
            LoadSongs();
            for (int i = 0; i < UserController.GetInstance().User.GetPlaylists().Count; i++)
            {
                for (int j = 0; j < UserController.GetInstance().User.GetPlaylists()[i].GetSonglist().Count; j++)
                {
                    MessageBox.Show(UserController.GetInstance().User.GetPlaylists()[i].GetSonglist()[j].GetSongname());
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            musicPlayer.Stop();
            this.Hide();
        }

        private void btn_Play_Click(object sender, System.EventArgs e)
        {
            btn_Play.Text = musicPlayer.isPaused ? @"▶" : @"❚❚";
            musicPlayer.Pause();
        }

        private void LoadPlaylists()
        {
            fLayout_Playlist_List.Controls.Clear();
            for (int i = 0; i < UserController.GetInstance().User.GetPlaylists().Count; i++)
            {
                Label playlistLabel = new Label();
                playlistLabel.Parent = fLayout_Playlist_List;
                playlistLabel.Font = lbl_Playlist_Unselected.Font;
                playlistLabel.Visible = true;
                playlistLabel.Margin = lbl_Playlist_Unselected.Margin;
                playlistLabel.AutoSize = lbl_Playlist_Unselected.AutoSize;
                playlistLabel.Text =
                    UserController.GetInstance().User.GetPlaylists()[i].GetPlaylistTitle();
                playlistLabel.ForeColor = lbl_Playlist_Unselected.ForeColor;
                playlistLabel.Click += UnselectedLabel_Click;
            }
        }

        private void LoadSongs()
        {

        }

        private void UnselectedLabel_Click(object sender, System.EventArgs e)
        {
            Label hoverLabel = sender as Label;
            if (hoverLabel != null)            
                GetSelectedPlaylistInfo(hoverLabel);
        }

        private void GetSelectedPlaylistInfo(Control control)
        {
            control.Font = lbl_Playlist_Selected.Font;
        }

        private void btn_NewPlaylist_Click(object sender, System.EventArgs e)
        {
            fLayout_NewPlaylist.Visible = true;
            fLayout_NewPlaylist.BringToFront();
        }

        private void btn_Create_Playlist_Click(object sender, System.EventArgs e)
        {
            PlaylistController.GetInstance()
                .CreatePlaylist(tBox_PlaylistName.Text, tBox_Description.Text, true);
            UserController.GetInstance()
                .LoadUserPlaylists(UserController.GetInstance().User.GetUserId());
            LoadPlaylists();
        }

        private void btn_Cancel_Playlist_Click(object sender, System.EventArgs e)
        {
            fLayout_NewPlaylist.Visible = false;
            tBox_PlaylistName.Text = string.Empty;
            tBox_Description.Text = string.Empty;
            fLayout_NewPlaylist.SendToBack();
        }
    }
}
