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
        public void DisplayPlayerSetup()
        {
            string userResponse;

            ConsoleUtil.HeaderText = "Initial Mission Parameters";
            ConsoleUtil.DisplayReset();

            //
            // get player's name
            //
            ConsoleUtil.DisplayPromptMessage("Enter your name: ");
            _gamePlayer.Name = Console.ReadLine();
            ConsoleUtil.DisplayMessage("");

            //
            // get player's race
            //
            _gamePlayer.Race = DisplayGetPlayersRace();
            ConsoleUtil.DisplayMessage("");

            //
            // get player's starting space-time location
            //
            DisplaySpaceTimeLocationTable();

            ConsoleUtil.DisplayPromptMessage("Enter your space-time destination ID: ");
            userResponse = Console.ReadLine();
            _gamePlayer.SpaceTimeLocationID = userResponse;

            ConsoleUtil.DisplayMessage("Your mission setup is complete.");

            DisplayContinuePrompt();
        }

        public Player.RaceType DisplayGetPlayersRace()
        {

            //
            // display all race types on a line
            //
            ConsoleUtil.DisplayMessage("Races");
            StringBuilder sb = new StringBuilder();
            foreach (Character.RaceType raceType in Enum.GetValues(typeof(Character.RaceType)))
            {
                sb.Append($" [{raceType}] ");
            }
            ConsoleUtil.DisplayMessage(sb.ToString());

            ConsoleUtil.DisplayPromptMessage("Enter your race: ");
            Character.RaceType playerRace;
            Enum.TryParse<Character.RaceType>(Console.ReadLine(), out playerRace);

            return playerRace;
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
            ConsoleUtil.DisplayMessage(" # ".PadRight(5) + "Location Name".PadRight(20) + "Location ID".PadRight(10));
            ConsoleUtil.DisplayMessage("---".PadRight(20) + "-----------".PadRight(10));

            //
            // location name and id
            //
            foreach (SpaceTimeLocation location in _gameUniverse.SpaceTimeLocations)
            {
                ConsoleUtil.DisplayMessage(locationNumber.ToString().PadRight(5) + location.Name.PadRight(20) + location.SpaceTimeLocationID.PadRight(10));
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
                    "\t" + "1. Setup Your Player" + Environment.NewLine +
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
                        userMenuChoice = MenuOption.PlayerSetup;
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

            DisplayContinuePrompt();
        }

        #endregion
    }
}
