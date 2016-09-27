using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    public class Controller
    {
        #region FIELDS

        private bool _usingGame;
        bool _missionInitialized = false;

        //
        // declare all objects required for the game
        // Note - these field objects do not require properties since they
        //        are not accessed outside of the controller
        //
        private ConsoleView _gameConsoleView;
        private Traveler _gamePlayer;
        private Universe _gameUniverse;

        #endregion

        #region PROPERTIES


        #endregion


        #region CONSTRUCTORS

        public Controller()
        {
            InitializeGame();

            //
            // instantiate a Salesperson object
            //
            _gamePlayer = new Traveler();

            //
            // instantiate a ConsoleView object
            //
            _gameConsoleView = new ConsoleView(_gamePlayer, _gameUniverse);

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion


        #region METHODS

        /// <summary>
        /// initialize the game 
        /// </summary>
        private void InitializeGame()
        {
            _usingGame = true;
            _gameUniverse = new Universe();
            _gamePlayer = new Traveler();
            _gameConsoleView = new ConsoleView(_gamePlayer, _gameUniverse);

            IntializeUniverse();
        }

        /// <summary>
        /// method to manage the application setup and control loop
        /// </summary>
        private void ManageGameLoop()
        {
            TravelerAction travelerActionChoice;

            _gameConsoleView.DisplayWelcomeScreen();

            InitializeMission();

            //
            // game loop
            //
            while (_usingGame)
            {

                //
                // get a menu choice from the ConsoleView object
                //
                travelerActionChoice = _gameConsoleView.DisplayGetTravelerActionChoice();

                //
                // choose an action based on the user's menu choice
                //
                switch (travelerActionChoice)
                {
                    case TravelerAction.None:
                        break;
                    case TravelerAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;
                    case TravelerAction.Travel:
                        _gamePlayer.SpaceTimeLocationID = _gameConsoleView.DisplayGetTravelersNewDestination().SpaceTimeLocationID;
                        break;
                    case TravelerAction.ListTARDISDestinations:
                        _gameConsoleView.DisplayListAllTARDISDestinations();
                        break;
                    case TravelerAction.TravlerInfo:
                        _gameConsoleView.DisplayTravelerInfo();
                        break;
                    case TravelerAction.Exit:
                        _usingGame = false;
                        break;
                    default:
                        break;
                }
            }

            _gameConsoleView.DisplayExitPrompt();

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// initialize the traveler's starting mission  parameters
        /// </summary>
        private void InitializeMission()
        {
            if (!_missionInitialized)
            {
                _gameConsoleView.DisplayMissionSetupIntro();
                _gamePlayer.Name = _gameConsoleView.DisplayGetTravelersName();
                _gamePlayer.Race = _gameConsoleView.DisplayGetTravelersRace();
                _gamePlayer.SpaceTimeLocationID = _gameConsoleView.DisplayGetTravelersNewDestination().SpaceTimeLocationID;
                _missionInitialized = true;
            }
        }

        /// <summary>
        /// initialize the universe with all of the space-time locations
        /// </summary>
        private void IntializeUniverse()
        {
            _gameUniverse.SpaceTimeLocations.Add(new SpaceTimeLocation
            {
                Name = "TARDIS Base",
                SpaceTimeLocationID = 1,
                Description = "The Norlon Corporation's secret laboratory located deep underground, " +
                              " beneath a nondescript 7-11 on the south-side of Toledo, OH.",
                Accessable = true
            });

            _gameUniverse.SpaceTimeLocations.Add(new SpaceTimeLocation
            {
                Name = "Xantoria Market",
                SpaceTimeLocationID = 2,
                Description = "The Xantoria market, once controlled by the Thorian elite, is now an " +
                              "open market managed by the Xantorian Commerce Coop. It is a place " +
                              "where many races from various systems trade goods.",
                Accessable = false
            });

            _gameUniverse.SpaceTimeLocations.Add(new SpaceTimeLocation
            {
                Name = "Felandrian Plains",
                SpaceTimeLocationID = 3,
                Description = "The Felandrian Plains are a common destination for tourist. " +
                  "Located just north of the equatorial line on the planet of Corlon, they" +
                  "provide excellent habitat for a rich ecosystem of flora and fauna.",
                Accessable = true
            });
        }

        #endregion
    }
}
