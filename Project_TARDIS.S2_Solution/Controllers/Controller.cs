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

        //
        // declare all objects required for the game
        // Note - these field objects do not require properties since they
        //        are not accessed outside of the controller
        //
        private ConsoleView _gameConsoleView;
        private Traveler _gameTraveler;
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
            _gameTraveler = new Traveler();

            //
            // instantiate a ConsoleView object
            //
            _gameConsoleView = new ConsoleView(_gameTraveler, _gameUniverse);

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
            _gameTraveler = new Traveler();
            _gameConsoleView = new ConsoleView(_gameTraveler, _gameUniverse);
        }
        /// <summary>
        /// initialize the traveler's starting mission  parameters
        /// </summary>
        private void InitializeMission()
        {
            //_gameConsoleView.DisplayMissionSetupIntro();
            _gameTraveler.Name = "Dyl";//_gameConsoleView.DisplayGetTravelersName();
            _gameTraveler.Race = Traveler.RaceType.Human;//_gameConsoleView.DisplayGetTravelersRace();
            _gameTraveler.SpaceTimeLocationID = 3;//_gameConsoleView.DisplayGetTravelersNewDestination().SpaceTimeLocationID;

            // 
            // add initial items to the traveler's inventory
            //
            foreach (Item item in _gameUniverse.GetItemsBySpaceTimeLocationID(0))
            {
                MoveItem(item, 0);
            }
            foreach (Treasure treasure in _gameUniverse.GetTreasuresBySpaceTimeLocationID(0))
            {
                MoveTreasure(treasure, 0);
            }
        }


        /// <summary>
        /// method to manage the application setup and control loop
        /// </summary>
        private void ManageGameLoop()
        {
            TravelerAction travelerActionChoice;

            //_gameConsoleView.DisplayWelcomeScreen();

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
                    case TravelerAction.LookAt:
                        //
                        // TODO write a DisplayLookAt method that lists game object name and details in the location
                        //
                        _gameConsoleView.DisplayLookAt();

                        break;
                    case TravelerAction.PickUpItem:
                        //
                        // TODO write a DisplayPickUpItem method in the ConsoleView that lists game objects in a location and prompts the traveler for an ID that is returned. Then adds the object to the traveler's inventory by adding them to the traveler's item list and setting the object's LocationID to 0.
                        //
                        //Item PickedUpItem = _gameConsoleView.DisplayPickUpItem();
                        //_gameTraveler.TravelersItems.Add(PickedUpItem);
                        //PickedUpItem.SpaceTimeLocationID = 0;
                        MoveItem(_gameConsoleView.DisplayPickUpItem(), 0);
                        break;
                    case TravelerAction.PickUpTreasure:
                        //
                        // TODO write a DisplayPickUpTreasure method in the ConsoleView that lists game treasures in a location and prompts the traveler for an ID that is returned. Then adds the object to the player's treasure by adding them to the traveler's treasure list and setting the object's LocationID to the location of the traveler.
                        //
                        MoveTreasure(_gameConsoleView.DisplayPickUpTreasure(), 0);
                        break;
                    case TravelerAction.PutDownItem:
                        //
                        // TODO write a DisplayPutDownItem method in the ConsoleView that lists the travelers game items and prompts the traveler for an ID that is returned. Then removes the object from the travel's items by removing it from the traveler's item list and setting the items's LocationID to the location of the traveler.
                        //
                        MoveItem(_gameConsoleView.DisplayPutDownItem(), _gameTraveler.SpaceTimeLocationID);
                        break;
                    case TravelerAction.PutDownTreasure:
                        //
                        // TODO write a DisplayPutDownTreasure method in the ConsoleView that lists the travelers game treasures and prompts the player for an ID that is returned. Then removes the object from the travel's treasure by removing it from the traveler's treasure list and setting the treasures's LocationID to the location of the traveler.
                        //
                        MoveTreasure(_gameConsoleView.DisplayPutDownTreasure(), _gameTraveler.SpaceTimeLocationID);
                        break;
                    case TravelerAction.Travel:
                        _gameTraveler.SpaceTimeLocationID = _gameConsoleView.DisplayGetTravelersNewDestination().SpaceTimeLocationID;
                        break;
                    case TravelerAction.TravelerInfo:
                        _gameConsoleView.DisplayTravelerInfo();
                        break;
                    case TravelerAction.TravelerInventory:
                        _gameConsoleView.DisplayTravelerItems();
                        break;
                    case TravelerAction.TravelerTreasure:
                        _gameConsoleView.DisplayTravelerTreasure();
                        break;
                    case TravelerAction.ListTARDISDestinations:
                        _gameConsoleView.DisplayListAllTARDISDestinations();
                        break;
                    case TravelerAction.ListItems:
                        _gameConsoleView.DisplayListAllGameItems();
                        break;
                    case TravelerAction.ListTreasures:
                        _gameConsoleView.DisplayListAllGameTreasures();
                        break;
                    case TravelerAction.Exit:
                        _usingGame = false;
                        break;
                    default:
                        break;
                }
            }

            _gameConsoleView.DisplayExitPrompt();
        }

        private void MoveItem(Item item, int newLocation)
        {
            if (item != null && item.CanAddToInventory) { 
                // If this treasure is in Player inventory it should be removed
                if (item.SpaceTimeLocationID == 0)
                    _gameTraveler.TravelersItems.Remove(item);

                // If newLocation is 0, treasure should be added to Player inventory
                if (newLocation == 0)
                    _gameTraveler.TravelersItems.Add(item);

                // Regardless, updating SpaceTimeLocationID is what actually "moves" the object in the universe
                item.SpaceTimeLocationID = newLocation;
            }
        }

        private void MoveTreasure(Treasure treasure, int newLocation)
        {
            if (treasure != null && treasure.CanAddToInventory)
            {

                // If this treasure is in Player inventory it should be removed
                if (treasure.SpaceTimeLocationID == 0)
                    _gameTraveler.TravelersTreasures.Remove(treasure);

                // If newLocation is 0, treasure should be added to Player inventory
                if (newLocation == 0)
                    _gameTraveler.TravelersTreasures.Add(treasure);

                // Regardless, updating SpaceTimeLocationID is what actually "moves" the object in the universe
                treasure.SpaceTimeLocationID = newLocation;
            }
        }

        #endregion
    }
}
