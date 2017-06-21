Imports System.Timers

Public Class Main

#If DEBUG Then

    Private WithEvents _Timer As Timer

#End If
    Public Shared Sub Send(
    keys As String
    )
    End Sub


    Private _MasteryManager As New MasteryManager

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            InitializeApplicationVersion()

            InitializeLoLClientVersion()

            InitializeChampions()

            InitializeRoles()

            InitializeStats()

#If DEBUG Then

            _Timer = New Timer(1000)

            _Timer.Enabled = True

#End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    
    Private Sub InitializeChampions()

        With cboChampion
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With

        _MasteryManager.PopulateChampions(cboChampion)

        cboChampion.SelectedIndex = 0

    End Sub

    Private Sub InitializeRoles()

        With cboRole
            .DropDownStyle = ComboBoxStyle.DropDownList
        End With

        _MasteryManager.PopulateRoles(cboRole, CType(cboChampion.SelectedItem, Champion))

        cboRole.SelectedIndex = 0

    End Sub

    Private Sub InitializeStats()

        With cboStats
            .DropDownStyle = ComboBoxStyle.DropDownList
        End With

        _MasteryManager.PopulateStats(cboStats)

        ' Use the "Highest Win" stat by default
        cboStats.SelectedIndex = 1

    End Sub

    Private Sub InitializeApplicationVersion()

        Dim oVersion As New Version

        Version.TryParse(ProductVersion, oVersion)

        lblVersion.Text = String.Format("{0}.{1}.{2}", oVersion.Major, oVersion.Minor, oVersion.Build)

        Dim oGitHubLink As New LinkLabel.Link()

        oGitHubLink.LinkData = My.Resources.GitHubLatestReleaseUrl

        lblVersion.Links.Add(oGitHubLink)

    End Sub

    Private Sub InitializeLoLClientVersion()

        lblClientVersion.Text = String.Format("Patch {0}", _MasteryManager.PatchNumber)

        Dim oChampionGGLink As New LinkLabel.Link

        oChampionGGLink.LinkData = My.Resources.ChampionGGUrl

        lblClientVersion.Links.Add(oChampionGGLink)

    End Sub

    Private Sub btnAssignMasteries_Click(sender As Object, e As EventArgs) Handles btnAssignMasteries.Click

        Try

            Dim sChampionKey As String = CType(cboChampion.SelectedItem, Champion).Key
            Dim sRole As String = cboRole.SelectedItem.ToString
            Dim sStat As String = cboStats.SelectedItem.ToString

            _MasteryManager.AssignMasteries(sChampionKey, sRole, sStat)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub cboChampion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboChampion.SelectedIndexChanged

        Try

            _MasteryManager.PopulateRoles(cboRole, CType(cboChampion.SelectedItem, Champion))

            cboRole.SelectedIndex = 0

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub chkInChampionSelect_CheckedChanged(sender As Object, e As EventArgs) Handles chkInChampionSelect.CheckedChanged

        Try

            If chkInChampionSelect.Checked Then

                _MasteryManager.SetMode(Modes.ChampionSelect)

            Else

                _MasteryManager.SetMode(Modes.Menu)

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub lblVersion_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblVersion.LinkClicked

        Try

            Process.Start(e.Link.LinkData.ToString)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub lblClientVersion_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblClientVersion.LinkClicked

        Try

            Process.Start(e.Link.LinkData.ToString)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub lblChampion_Click(sender As Object, e As EventArgs) Handles lblChampion.Click

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub updatebutton_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles updatebutton.LinkClicked
        CheckForUpdates()

    End Sub
    Public Sub CheckForUpdates()
        Dim request As System.Net.HttpWebRequest = CType(System.Net.HttpWebRequest.Create("https://dl.dropboxusercontent.com/s/8h8o1pb0dhwhqkd/version.txt"), Net.HttpWebRequest)
        Dim response As System.Net.HttpWebResponse = CType(request.GetResponse(), Net.HttpWebResponse)
        Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
        Dim newestversion As String = sr.ReadToEnd()
        Dim currentversion As String = Application.ProductVersion
        If newestversion.Contains(currentversion) Then
            MsgBox("You are up todate!")
        Else
            MsgBox("There is a new update we, will download it now for you.")
            WebBrowser1.Navigate("https://dl.dropbox.com/s/lm7iaegv3w0ht7q/LoLMasteryManagerSetup.msi")
        End If
    End Sub


#If DEBUG Then

    Private Sub _Timer_Elapsed(sender As Object, e As ElapsedEventArgs) Handles _Timer.Elapsed

        Dim oLeagueWindow As IntPtr = HwndInterface.GetHwndFromTitle(My.Resources.LeagueClientWindowTitle)

        Dim oLeagueSize = HwndInterface.GetHwndSize(oLeagueWindow)
        Dim oLeaguePosition = HwndInterface.GetHwndPos(oLeagueWindow)

        Debug.WriteLine(String.Format("Client: {{ {0}, {1} }}", oLeaguePosition, oLeagueSize))
        Debug.WriteLine(New Point(Cursor.Position.X - oLeaguePosition.X, Cursor.Position.Y - oLeaguePosition.Y))

    End Sub

#End If

End Class
