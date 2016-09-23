using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    /// <summary>
    /// Console class for the MVC pattern
    /// </summary>
    public class ConsoleView
    {
        #region FIELDS

        //
        // declare a Universe and Player object for the ConsoleView object to use
        //
        Universe _gameUniverse;
        Player _gamePlayer;
        bool _missionInitialized = false;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Player gamePlayer, Universe gameUniverse)
        {
            _gamePlayer = gamePlayer;
            _gameUniverse = gameUniverse;

            InitializeConsole();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize all console settings
        /// </summary>
        private void InitializeConsole()
        {
            ConsoleUtil.WindowTitle = "Laughing Leaf Productions";
            ConsoleUtil.HeaderText = "The TARDIS Project";
        }

        /// <summary>
        /// display the Continue prompt
        /// </summary>
        public void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;

            Console.WriteLine();

            ConsoleUtil.DisplayMessage("Press any key to continue.");
            ConsoleKeyInfo response = Console.ReadKey();

            Console.WriteLine();

            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the Exit prompt on a clean screen
        /// </summary>
        public void DisplayExitPrompt()
        {
            ConsoleUtil.DisplayReset();

            Console.CursorVisible = false;

            Console.WriteLine();
            ConsoleUtil.DisplayMessage("Thank you for playing The TARDIS Project. Press any key to Exit.");

            Console.ReadKey();

            System.Environment.Exit(1);
        }


        /// <summary>
        /// display the welcome screen
        /// </summary>
        public void DisplayWelcomeScreen()
        {
            StringBuilder sb = new StringBuilder();

            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("The TARDIS Project");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Written by John Velis");
            ConsoleUtil.DisplayMessage("Northwestern Michigan College");
            Console.WriteLine();

            //
            // TODO update opening screen
            //

            sb.Clear();
            sb.AppendFormat("You have been hired by the Norlon Corporation to participate ");
            sb.AppendFormat("in its latest endeavor, the TARDIS Project. Your mission is to ");
            sb.AppendFormat("test the limits of the new TARDIS Machine and report back to ");
            sb.AppendFormat("the Norlon Corporation.");
            ConsoleUtil.DisplayMessage(sb.ToString());
            Console.WriteLine();

            sb.Clear();
            sb.AppendFormat("Your first task will be to set up the initial parameters of your mission.");
            ConsoleUtil.DisplayMessage(sb.ToString());

            DisplayContinuePrompt();
        }

        /// <summary>
        /// setup the new Player object
        /// </summary>
        public void DisplayMissionSetup()
        {
            if (!_missionInitialized)
            {
                //
                // display header
                //
                ConsoleUtil.HeaderText = "Mission Setup";
                ConsoleUtil.DisplayReset();

                //
                // display intro
                //
                ConsoleUtil.DisplayMessage("You will now be prompted to enter the starting parameters of your mission.");
                DisplayContinuePrompt();

                //
                // get player's name
                //
                _gamePlayer.Name = DisplayGetPlayersName();

                //
                // get player's race
                //
                _gamePlayer.Race = DisplayGetPlayersRace();

                //
                // get player's starting space-time location
                //
                _gamePlayer.SpaceTimeLocationID = DisplayGetPlayersNextLocation().SpaceTimeLocationID;

                //
                // set mission initialized status
                //
                _missionInitialized = true;
            }

            //
            // display confirmation 
            //
            //
            // display header
            //
            ConsoleUtil.HeaderText = "Mission Setup";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Your mission setup is complete.");
            DisplayContinuePrompt();
        }

        /// <summary>
        /// get player's name
        /// </summary>
        /// <returns>name as a string</returns>
        private string DisplayGetPlayersName()
        {
            string playersName;

            //
            // display header
            //
            ConsoleUtil.HeaderText = "Traveler's Name";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayPromptMessage("Enter your name: ");
            playersName = Console.ReadLine();

            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayMessage($"You have indicated {playersName} as your name.");

            DisplayContinuePrompt();

            return playersName;
        }

        /// <summary>
        /// get and validate the player's race
        /// </summary>
        /// <returns>race as a RaceType</returns>
        public Player.RaceType DisplayGetPlayersRace()
        {
            bool validResponse = false;
            Player.RaceType playersRace = Player.RaceType.None;

            while (!validResponse)
            {
                //
                // display header
                //
                ConsoleUtil.HeaderText = "Traveler's Race";
                ConsoleUtil.DisplayReset();

                //
                // display all race types on a line
                //
                ConsoleUtil.DisplayMessage("Races");
                StringBuilder sb = new StringBuilder();
                foreach (Character.RaceType raceType in Enum.GetValues(typeof(Character.RaceType)))
                {
                    if (raceType != Character.RaceType.None)
                    {
                        sb.Append($" [{raceType}] ");
                    }

                }
                ConsoleUtil.DisplayMessage(sb.ToString());

                ConsoleUtil.DisplayPromptMessage("Enter your race: ");

                //
                // validate user response for race
                //
                if (Enum.TryParse<Character.RaceType>(Console.ReadLine(), out playersRace))
                {
                    validResponse = true;
                    ConsoleUtil.DisplayReset();
                    ConsoleUtil.DisplayMessage($"You have indicated {playersRace} as your race type.");
                }
                else
                {
                    ConsoleUtil.DisplayMessage("You must limit your race to the list above.");
                    ConsoleUtil.DisplayMessage("Please reenter your race.");
                }

                DisplayContinuePrompt();
            }

            return playersRace;
        }

        //
        // get and validate the player's TARDIS destination
        //
        private SpaceTimeLocation DisplayGetPlayersNextLocation()
        {
            bool validResponse = false;
            int locationNumber;
            SpaceTimeLocation nextSpaceTimeLocation = new SpaceTimeLocation();

            while (!validResponse)
            {
                //
                // display header
                //
                ConsoleUtil.HeaderText = "TARDIS Destination";
                ConsoleUtil.DisplayReset();

                //
                // display a table of space-time locations
                //
                DisplaySpaceTimeLocationTable();

                //
                // get and validate user's response for a space-time location
                //
                ConsoleUtil.DisplayPromptMessage("Choose the Space-Time destination by entering the location ID: ");
                // user's response is an integer
                if (int.TryParse(Console.ReadLine(), out locationNumber))
                {
                    // user's response is within the proper range
                    if (locationNumber > 0 && locationNumber <= _gameUniverse.SpaceTimeLocations.Count())
                    {
                        //
                        // run through the space-time location list and grab the correct one
                        //
                        foreach (SpaceTimeLocation location in _gameUniverse.SpaceTimeLocations)
                        {
                            if (location.SpaceTimeLocationID == locationNumber)
                            {
                                nextSpaceTimeLocation = location;
                            }
                        }

                        validResponse = true;
                        ConsoleUtil.DisplayReset();
                        ConsoleUtil.DisplayMessage($"You have indicated {nextSpaceTimeLocation.Name} as your TARDIS destination.");
                    }
                    // user's response was not in the correct range
                    else
                    {
                        ConsoleUtil.DisplayPromptMessage("It appears you entered an invalid location ID.");
                        ConsoleUtil.DisplayMessage("Please try again.");
                    }
                }
                // user's response was not an integer
                else
                {
                    ConsoleUtil.DisplayPromptMessage("It appears you did not enter a number for the location ID.");
                    ConsoleUtil.DisplayMessage("Please try again.");
                }

                DisplayContinuePrompt();
            }

            return nextSpaceTimeLocation;
        }

        /// <summary>
        /// generate a table of space-time location names and ids
        /// </summary>
        public void DisplaySpaceTimeLocationTable()
        {
            int locationNumber = 1;

            //
            // table headings
            //
            ConsoleUtil.DisplayMessage("ID".PadRight(10) + "Name".PadRight(20));
            ConsoleUtil.DisplayMessage("---".PadRight(10) + "-------------".PadRight(20));

            //
            // location name and id
            //
            foreach (SpaceTimeLocation location in _gameUniverse.SpaceTimeLocations)
            {
                ConsoleUtil.DisplayMessage(location.SpaceTimeLocationID.ToString().PadRight(10) + location.Name.PadRight(20));
                locationNumber++;
            }

        }

        /// <summary>
        /// get the menu choice from the user
        /// </summary>
        public MenuOption DisplayGetUserMenuChoice()
        {
            MenuOption userMenuChoice = MenuOption.None;
            bool usingMenu = true;

            while (usingMenu)
            {
                //
                // set up display area
                //
                ConsoleUtil.DisplayReset();
                Console.CursorVisible = false;

                //
                // display the menu
                //
                ConsoleUtil.DisplayMessage("Please type the number of your menu choice.");
                Console.WriteLine();
                Console.WriteLine(
                    "\t" + "1. Initialize Your Mission" + Environment.NewLine +
                    "\t" + "2. Travel to a New Space-Time Location" + Environment.NewLine +
                    "\t" + "3. Display Space-Time Location Info" + Environment.NewLine +
                    "\t" + "4. Display Player Info" + Environment.NewLine +
                    "\t" + "E. Exit" + Environment.NewLine);

                //
                // get and process the user's response
                // note: ReadKey argument set to "true" disables the echoing of the key press
                //
                ConsoleKeyInfo userResponse = Console.ReadKey(true);
                switch (userResponse.KeyChar)
                {
                    case '1':
                        userMenuChoice = MenuOption.MissionSetup;
                        usingMenu = false;
                        break;
                    case '2':
                        userMenuChoice = MenuOption.SpaceTimeTravel;
                        usingMenu = false;
                        break;
                    case '3':
                        userMenuChoice = MenuOption.SpaceTimeLocationInfo;
                        usingMenu = false;
                        break;
                    case '4':
                        userMenuChoice = MenuOption.PlayerInfo;
                        usingMenu = false;
                        break;
                    case 'E':
                    case 'e':
                        userMenuChoice = MenuOption.Exit;
                        usingMenu = false;
                        break;
                    default:
                        Console.WriteLine(
                            "It appears you have selected an incorrect choice." + Environment.NewLine +
                            "Press any key to continue or the ESC key to quit the application.");

                        userResponse = Console.ReadKey(true);
                        if (userResponse.Key == ConsoleKey.Escape)
                        {
                            usingMenu = false;
                        }
                        break;
                }
            }
            Console.CursorVisible = true;

            return userMenuChoice;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>string City</returns>
        public string DisplayTravelToSpaceTimeLocation()
        {
            string nextCity = "";

            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayPromptMessage("Enter the name of the next city:");
            nextCity = Console.ReadLine();

            return nextCity;
        }

        /// <summary>
        ///
        /// <summary>
        /// display all space-time locations
        /// </summary>
        public void DisplaySpaceTimeLocations()
        {
            ConsoleUtil.HeaderText = "Space-Time Locations";
            ConsoleUtil.DisplayReset();

            DisplayContinuePrompt();
        }
        
        /// <summary>
        /// display the current account information
        /// </summary>
        public void DisplayPlayerInfo()
        {
            ConsoleUtil.HeaderText = "Player Info";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage($"Player's Name: {_gamePlayer.Name}");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage($"Player's Race: {_gamePlayer.Race}");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage($"Player's Current Location: {_gamePlayer.Race}");

            DisplayContinuePrompt();
        }

        #endregion
    }
}
