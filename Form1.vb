Public Class Form1

    Dim strHold As String ' Holds the value for the lowercase version of the text input
    Dim strState As String ' Holds the value for the current state of the game
    Dim intHold As Integer ' Holds temporary integer values for things like random chances

    Dim gen As New System.Random ' Random number generator

    Dim strParty As String ' Holds the name of the party
    Dim strMemOne, strMemTwo, strMemThree As String ' Holds the name of the party members

    Dim intHealthOne, intAttackOne As Integer ' Holds the health and attack stat of Member one
    Dim intHealthTwo, intAttackTwo As Integer ' Holds the health and attack stat of Member Two
    Dim intHealthThree, intAttackThree, intMagicThree As Integer 'Holds the health, attack, and magic stat of mem3

    Dim strObserve As String = "Start the game before looking around. A little anxious yeah?" ' Holds the current surroundings





    'Tool strips
    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub CreditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreditsToolStripMenuItem.Click
        MessageBox.Show("Created by Mitch Bath")
    End Sub


    Private Sub CommandsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CommandsToolStripMenuItem.Click
        MessageBox.Show("Commands" & vbCrLf & "Start - Begins a new adventure" & vbCrLf & "Observe - Returns an overview of your surroundings" & vbCrLf & "Attack - Performs a basic attack" & vbCrLf & "Defend - The party member takes reduced damage for one turn" & vbCrLf & "Spells - Only the mage can use this. Displays usable spells." & vbCrLf & "Flee - Has a chance to end the battle with no rewards" & vbCrLf & "Stats - Displays basic stats about your party" & vbCrLf & "-")
    End Sub

    Private Sub HighScoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HighScoreToolStripMenuItem.Click

    End Sub

    Private Sub SpellsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpellsToolStripMenuItem.Click

    End Sub

    Private Sub txtInput_KeyDown(sender As Object, e As KeyEventArgs) Handles txtInput.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            lstDisplay.Items.Add("")
            lstDisplay.Items.Add(" > " & txtInput.Text)
            lstDisplay.Items.Add("")
            'Do not edit above this line in this sub


            If strState = "memthreename" Then
                strMemThree = txtInput.Text
                lstDisplay.Items.Add("If the following information is not what you desire, type 'Start'")
                lstDisplay.Items.Add("Party: " & strParty & ", consisting of " & strMemOne & ", " & strMemTwo & ", and " & strMemThree)
                lstDisplay.Items.Add("If you are ready, type 'Begin'")
                strState = "begin"
            End If
            If strState = "memtwoname" Then
                strMemTwo = txtInput.Text
                lstDisplay.Items.Add("The third and final member is a female wizard who relies on using resourceful spells to alter combat in her favor.")
                lstDisplay.Items.Add("What is her name?")
                strState = "memthreename"
            End If
            If strState = "memonename" Then
                strMemOne = txtInput.Text
                lstDisplay.Items.Add("The second member is a female rogue who attacks with her twin daggers to try to get criticals.")
                lstDisplay.Items.Add("What is her name?")
                strState = "memtwoname"
            End If
            If strState = "partyname" Then
                strParty = txtInput.Text
                lstDisplay.Items.Add("The first member of " & strParty & " is a strong male warrior who can take lots of damage.")
                lstDisplay.Items.Add("What is his name?")
                strState = "memonename"
            End If
            '-
            strHold = txtInput.Text.ToLower


            If strHold = "observe" Then
                lstDisplay.Items.Add(strObserve)
            End If



            If strHold = "start" Then
                lstDisplay.Items.Clear()
                intHealthOne = 20
                intAttackOne = 4

                intHealthTwo = 10
                intAttackTwo = 2

                intHealthThree = 15
                intAttackThree = 1
                intMagicThree = 10

                strObserve = "You don't even exist yet."

                lstDisplay.Items.Add("Welcome.")
                lstDisplay.Items.Add("You are about to set off on an epic journey")
                lstDisplay.Items.Add("But first, what is the name of your party?")
                strState = "partyname"
            End If




            If strHold = "begin" Then 'Executed right after names are inputted
                If strState = "begin" Then
                    strObserve = "Everything is black..."
                    lstDisplay.Items.Add("Legend says that atop the tower of Nightingale lies a treasure chest with infinite riches.")
                    lstDisplay.Items.Add(strParty & " stands before the entrence. Legend also says those who enter never come out.")
                    lstDisplay.Items.Add("But money is tight, and " & strParty & " needs all they can get.")
                    lstDisplay.Items.Add(strMemOne & " steps inside, and " & strMemTwo & " and " & strMemThree & " follow.")
                    lstDisplay.Items.Add("")
                    lstDisplay.Items.Add("The circular room is pitch black with the exception of a torchlit staircase.")
                    lstDisplay.Items.Add(strParty & " ascends into the unknown.")
                    Room(intHold, strParty, strHold, strState, strMemOne, strMemTwo, strMemThree, intHealthOne, intAttackOne, intHealthTwo, intAttackTwo, intHealthThree, intAttackThree, intMagicThree, strObserve)
                End If
            End If




            'Do not edit below this line in this sub
            If lstDisplay.Items.Count >= 27 Then
                Do While lstDisplay.Items.Count >= 27
                    lstDisplay.Items.RemoveAt(0)
                Loop
            End If
            txtInput.Text = Nothing
        End If 'End if for the original Keycode = Keys.Enter
    End Sub




    Public Sub Room(ByRef intHold As Integer, ByRef strParty As String, ByRef strHold As String, ByRef strState As String, ByRef strMemOne As String, ByRef strMemTwo As String, ByRef strMemThree As String, ByRef intHealthOne As Integer, ByRef intAttackOne As Integer, ByRef intHealthTwo As Integer, ByRef intAttackTwo As Integer, ByRef intHealthThree As Integer, ByRef intAttackThree As Integer, ByRef intMagicThree As Integer, ByRef strObserve As String)
        intHold = gen.Next(1, 5) ' Picks which room the player gets: Battle, Item, Story room, or code room.
        Select Case intHold
            Case 1
                'Create battle subs and pick a random one to call here
            Case 2
                'Create item sub
            Case 3
                'Getting this advances the story
            Case 4
                'The player must decipher a code
        End Select
    End Sub



    Public Sub Code(ByRef intHold As Integer, ByRef strParty As String, ByRef strHold As String, ByRef strState As String, ByRef strMemOne As String, ByRef strMemTwo As String, ByRef strMemThree As String, ByRef intHealthOne As Integer, ByRef intAttackOne As Integer, ByRef intHealthTwo As Integer, ByRef intAttackTwo As Integer, ByRef intHealthThree As Integer, ByRef intAttackThree As Integer, ByRef intMagicThree As Integer, ByRef strObserve As String)

    End Sub










End Class
