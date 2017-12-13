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

    Dim strMonster As String = "ERROR: MONSTER NAME NOT FOUND" ' Holds name of the monster
    Dim intHealthMonster, intAttackMonster As Integer ' Holds the health and attack stat of the current monster

    Dim strObserve As String = "Start the game before looking around. A little anxious yeah?" ' Holds the current surroundings

    Private Sub txtInput_KeyDown(sender As Object, e As KeyEventArgs) Handles txtInput.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            lstDisplay.Items.Add("")
            lstDisplay.Items.Add(" > " & txtInput.Text)
            lstDisplay.Items.Add("")
            'Do not edit above this line in this sub; Standard input code


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
            '- ToLower is down here so that names can be uppercase above this line
            strHold = txtInput.Text.ToLower


            If strHold = "observe" Then
                lstDisplay.Items.Add(strObserve)
            End If



            If strHold = "start" Then
                lstDisplay.Items.Clear()
                lstItems.Items.Clear()
                intHealthOne = 20
                intAttackOne = 4

                intHealthTwo = 10
                intAttackTwo = 2

                intHealthThree = 15
                intAttackThree = 1
                intMagicThree = 10

                strObserve = "You don't even exist yet."

                lstItems.Items.Add("Divine Blessing")

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

            If strState = "battle1" Then 'Party memebr 1s turn
                If strHold = "attack" Then
                    Dim intRandom As Integer = gen.Next(1, 11)
                    If intRandom = 10 Then
                        intHealthMonster = intHealthMonster - (intAttackOne + (intAttackOne / 2))
                        lstDisplay.Items.Add("Critical Hit!")
                    Else
                        intHealthMonster = intHealthMonster - intAttackOne
                    End If
                    If DeathCheck(intHealthMonster) = True Then
                        lstDisplay.Items.Add("The " + strMonster + " is defeated.")
                        Select Case gen.Next(1, 4)
                            Case 1
                                intHealthOne = intHealthOne + gen.Next(1, 6)
                                intAttackOne = intAttackOne + gen.Next(1, 3)
                                lstDisplay.Items.Add(strMemOne + " leveled up!")
                            Case 2
                                intHealthTwo = intHealthTwo + gen.Next(1, 5)
                                intAttackTwo = intAttackTwo + gen.Next(1, 3)
                                lstDisplay.Items.Add(strMemTwo + " leveled up!")
                            Case 3
                                intHealthThree = intHealthThree + gen.Next(1, 5)
                                intAttackThree = intAttackThree + gen.Next(1, 3)
                                lstDisplay.Items.Add(strMemThree + " leveled up!")
                        End Select
                    End If
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
                Battle(intHold, strParty, strHold, strState, strMemOne, strMemTwo, strMemThree, intHealthOne, intAttackOne, intHealthTwo, intAttackTwo, intHealthThree, intAttackThree, intMagicThree, strObserve, intHealthMonster, intAttackMonster, strMonster)
                'Create battle subs and pick a random one to call here
            Case 2
                'Create item sub
            Case 3
                'Getting this advances the story
            Case 4
                'The player must decipher a code
        End Select
    End Sub

    'Subs
    Public Sub Battle(ByRef intHold As Integer, ByRef strParty As String, ByRef strHold As String, ByRef strState As String, ByRef strMemOne As String, ByRef strMemTwo As String, ByRef strMemThree As String, ByRef intHealthOne As Integer, ByRef intAttackOne As Integer, ByRef intHealthTwo As Integer, ByRef intAttackTwo As Integer, ByRef intHealthThree As Integer, ByRef intAttackThree As Integer, ByRef intMagicThree As Integer, ByRef strObserve As String, ByRef intHealthMonster As Integer, ByRef intAttackMonster As Integer, ByRef strMonster As String)
        Dim intRandom = gen.Next(1, 11)
        strState = "battle1" 'First party member turn
        Select Case intRandom
            Case 1
                strMonster = "skeleton"
                strObserve = "A dastardy mass of rattling bones stands in your path."
                intHealthMonster = ((intHealthOne + intHealthTwo + intHealthThree) / 3) + 5
            Case 2
                strMonster = "wolf"
                strObserve = "A fiendish wolf has his eyes fixed on you. It snarls and prepares to attack."
                intHealthMonster = ((intHealthOne + intHealthTwo + intHealthThree) / 3) + 4
            Case 3
                strMonster = "gargoyle"
                strObserve = "A creature of stone is determined to end your quest."
                intHealthMonster = ((intHealthOne + intHealthTwo + intHealthThree) / 3) + 7
            Case 4
                strMonster = "troll"
                strObserve = "A hideous creature is angry that you have interrupted its business."
                intHealthMonster = ((intHealthOne + intHealthTwo + intHealthThree) / 3) + 6
            Case 5
                strMonster = "creature of the undead"
                strObserve = "Some undead creature has decided that you are its lunch."
                intHealthMonster = ((intHealthOne + intHealthTwo + intHealthThree) / 3) + 4
            Case 6
                strMonster = "libtard"
                strObserve = "A horrible creature is trying to get you to Pokemon Go to the polls!"
                intHealthMonster = ((intHealthOne + intHealthTwo + intHealthThree) / 3) + 1
            Case 7
                strMonster = "fire elemental"
                strObserve = "A being of pure flames has decided that you need to join the ashes below it."
                intHealthMonster = ((intHealthOne + intHealthTwo + intHealthThree) / 3) + 5
            Case 8
                strMonster = "water elemental"
                strObserve = "A being of pure water has decided that your lungs no longer need oxygen."
                intHealthMonster = ((intHealthOne + intHealthTwo + intHealthThree) / 3) + 5
            Case 9
                strMonster = "lightning elemental"
                strObserve = "A being of pure electric energy has decided that you just don't have that spark anymore."
                intHealthMonster = ((intHealthOne + intHealthTwo + intHealthThree) / 3) + 5
            Case 10
                strMonster = "malformed creature"
                strObserve = "You are not sure what that thing is, but it definitely wants to kill you."
                intHealthMonster = ((intHealthOne + intHealthTwo + intHealthThree) / 3) + 9
        End Select
        lstDisplay.Items.Add("You encounter a " + strMonster + "!")
        lstDisplay.Items.Add("It is " + strMemOne + "'s turn.")
    End Sub
    Function DeathCheck(ByVal intHealthMonster As Integer) As Boolean
        If intHealthMonster < 1 Then
            Return True
        Else
            Return False
        End If
    End Function




    Public Sub Code(ByRef intHold As Integer, ByRef strParty As String, ByRef strHold As String, ByRef strState As String, ByRef strMemOne As String, ByRef strMemTwo As String, ByRef strMemThree As String, ByRef intHealthOne As Integer, ByRef intAttackOne As Integer, ByRef intHealthTwo As Integer, ByRef intAttackTwo As Integer, ByRef intHealthThree As Integer, ByRef intAttackThree As Integer, ByRef intMagicThree As Integer, ByRef strObserve As String)

    End Sub



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
End Class
