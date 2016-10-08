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
        // declare a Universe and Traveler object for the ConsoleView object to use
        //
        Universe _gameUniverse;
        Traveler _gamePlayer;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Traveler gamePlayer, Universe gameUniverse)
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
            ConsoleUtil.WindowTitle = "The TARDIS Project";
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
            ConsoleUtil.HeaderText = "Exit";
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
        /// setup the new Traveler object
        /// </summary>
        public void DisplayMissionSetupIntro()
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
        }

        /// <summary>
        /// display a message confirming mission setup
        /// </summary>
        public void DisplayMissionSetupConfirmation()
        {
            //
            // display header
            //
            ConsoleUtil.HeaderText = "Mission Setup";
            ConsoleUtil.DisplayReset();
            ConsoleUtil.HeaderText = "Mission Setup";
            ConsoleUtil.DisplayReset();

            //
            // display confirmation
            //
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Your mission setup is complete.");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("To view your TARDIS traveler information use the Main Menu.");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// get player's name
        /// </summary>
        /// <returns>name as a string</returns>
        public string DisplayGetTravelersName()
        {
            string travelersName;

            //
            // display header
            //
            ConsoleUtil.HeaderText = "Traveler's Name";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayPromptMessage("Enter your name: ");
            travelersName = Console.ReadLine();

            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayMessage($"You have indicated {travelersName} as your name.");

            DisplayContinuePrompt();

            return travelersName;
        }

        /// <summary>
        /// get and validate the player's race
        /// </summary>
        /// <returns>race as a RaceType</returns>
        public Traveler.RaceType DisplayGetTravelersRace()
        {
            bool validResponse = false;
            Traveler.RaceType travelersRace = Traveler.RaceType.None;

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
                if (Enum.TryParse<Character.RaceType>(Console.ReadLine(), out travelersRace))
                {
                    validResponse = true;
                    ConsoleUtil.DisplayReset();
                    ConsoleUtil.DisplayMessage($"You have indicated {travelersRace} as your race type.");
                }
                else
                {
                    ConsoleUtil.DisplayMessage("You must limit your race to the list above.");
                    ConsoleUtil.DisplayMessage("Please reenter your race.");
                }

                DisplayContinuePrompt();
            }

            return travelersRace;
        }

        //
        // get and validate the player's TARDIS destination
        //
        public SpaceTimeLocation DisplayGetTravelersNewDestination()
        {
            bool validResponse = false;
            int locationID;
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
                DisplayTARDISDestinationsTable();

                //
                // get and validate user's response for a space-time location
                //
                ConsoleUtil.DisplayPromptMessage("Choose the TARDIS destination by entering the ID: ");

                //
                // user's response is an integer
                //
                if (int.TryParse(Console.ReadLine(), out locationID))
                {
                    ConsoleUtil.DisplayMessage("");

                    try
                    {
                        nextSpaceTimeLocation = _gameUniverse.GetSpaceTimeLocationByID(locationID);

                        ConsoleUtil.DisplayReset();
                        ConsoleUtil.DisplayMessage($"You have indicated {nextSpaceTimeLocation.Name} as your TARDIS destination.");
                        ConsoleUtil.DisplayMessage("");

                        if (nextSpaceTimeLocation.Accessable == true)
                        {
                            validResponse = true;
                            ConsoleUtil.DisplayMessage("You will be transported immediately.");
                        }
                        else
                        {
                            ConsoleUtil.DisplayMessage("It appears this destination is not available to you at this time.");
                            ConsoleUtil.DisplayMessage("Please make another choice.");
                        }
                    }
                    //
                    // user's response was not in the correct range
                    //
                    catch (ArgumentOutOfRangeException ex)
                    {
                        ConsoleUtil.DisplayMessage("It appears you entered an invalid location ID.");
                        ConsoleUtil.DisplayMessage(ex.Message);
                        ConsoleUtil.DisplayMessage("Please try again.");
                    }
                }
                //
                // user's response was not an integer
                //
                else
                {
                    ConsoleUtil.DisplayMessage("It appears you did not enter a number for the location ID.");
                    ConsoleUtil.DisplayMessage("Please try again.");
                }

                DisplayContinuePrompt();
            }

            return nextSpaceTimeLocation;
        }

        /// <summary>
        /// generate a table of space-time location names and ids
        /// </summary>
        public void DisplayTARDISDestinationsTable()
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
        /// get the action choice from the user
        /// </summary>
        public TravelerAction DisplayGetTravelerActionChoice()
        {
            TravelerAction travelerActionChoice = TravelerAction.None;
            bool usingMenu = true;

            while (usingMenu)
            {
                //
                // set up display area
                //
                ConsoleUtil.HeaderText = "Traveler Action Choice";
                ConsoleUtil.DisplayReset();
                Console.CursorVisible = false;

                //
                // display the menu
                //
                ConsoleUtil.DisplayMessage("What would you like to do (Type Number).");
                Console.WriteLine();
                Console.WriteLine(
                    "\t" + "1. Look Around" + Environment.NewLine +
                    "\t" + "2. Travel" + Environment.NewLine +
                    "\t" + "3. Display All TARDIS Destinations" + Environment.NewLine +
                    "\t" + "4. Display Traveler Info" + Environment.NewLine +
                    "\t" + "E. Exit" + Environment.NewLine);

                //
                // get and process the user's response
                // note: ReadKey argument set to "true" disables the echoing of the key press
                //
                ConsoleKeyInfo userResponse = Console.ReadKey(true);
                switch (userResponse.KeyChar)
                {
                    case '1':
                        travelerActionChoice = TravelerAction.LookAround;
                        usingMenu = false;
                        break;
                    case '2':
                        travelerActionChoice = TravelerAction.Travel;
                        usingMenu = false;
                        break;
                    case '3':
                        travelerActionChoice = TravelerAction.ListTARDISDestinations;
                        usingMenu = false;
                        break;
                    case '4':
                        travelerActionChoice = TravelerAction.TravlerInfo;
                        usingMenu = false;
                        break;
                    case 'E':
                    case 'e':
                        travelerActionChoice = TravelerAction.Exit;
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

            return travelerActionChoice;
        }

        /// <summary>
        /// display information about the current space-time location
        /// </summary>
        public void DisplayLookAround()
        {
            ConsoleUtil.HeaderText = "Current Space-Time Location Info";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage(_gameUniverse.GetSpaceTimeLocationByID(_gamePlayer.SpaceTimeLocationID).Description);

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a list of all TARDIS destinations
        /// <summary>
        /// display all space-time locations
        /// </summary>
        public void DisplayListAllTARDISDestinations()
        {
            ConsoleUtil.HeaderText = "Space-Time Locations";
            ConsoleUtil.DisplayReset();

            foreach (SpaceTimeLocation location in _gameUniverse.SpaceTimeLocations)
            {
                ConsoleUtil.DisplayMessage("ID: " + location.SpaceTimeLocationID);
                ConsoleUtil.DisplayMessage("Name: " + location.Name);
                ConsoleUtil.DisplayMessage("Description: " + location.Description);
                ConsoleUtil.DisplayMessage("Accessible: " + location.Accessable);
                ConsoleUtil.DisplayMessage("");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display the current traveler information
        /// </summary>
        public void DisplayTravelerInfo()
        {
            ConsoleUtil.HeaderText = "Traveler Info";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage($"Traveler's Name: {_gamePlayer.Name}");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage($"Traveler's Race: {_gamePlayer.Race}");
            ConsoleUtil.DisplayMessage("");
            string spaceTimeLocationName = _gameUniverse.GetSpaceTimeLocationByID(_gamePlayer.SpaceTimeLocationID).Name;
            ConsoleUtil.DisplayMessage($"Traveler's Current Location: {spaceTimeLocationName}");

            DisplayContinuePrompt();
        }

        #endregion
    }
}
