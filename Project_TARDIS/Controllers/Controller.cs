﻿using System;
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
        private Player _gamePlayer;
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
            _gamePlayer = new Player();

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
            _gamePlayer = new Player();
            _gameConsoleView = new ConsoleView(_gamePlayer, _gameUniverse);

            IntializeUniverse();
        }

        /// <summary>
        /// method to manage the application setup and control loop
        /// </summary>
        private void ManageGameLoop()
        {
            MenuOption userMenuChoice;

            _gameConsoleView.DisplayWelcomeScreen();

            //
            // game loop
            //
            while (_usingGame)
            {

                //
                // get a menu choice from the ConsoleView object
                //
                userMenuChoice = _gameConsoleView.DisplayGetUserMenuChoice();

                //
                // choose an action based on the user's menu choice
                //
                switch (userMenuChoice)
                {
                    case MenuOption.None:
                        break;
                    case MenuOption.MissionSetup:
                        if (!_missionInitialized)
                        {
                            _gameConsoleView.DisplayMissionSetupIntro();
                            _gamePlayer.Name = _gameConsoleView.DisplayGetPlayersName();
                            _gamePlayer.Race = _gameConsoleView.DisplayGetPlayersRace();
                            _gamePlayer.SpaceTimeLocationID = _gameConsoleView.DisplayGetPlayersNextLocation().SpaceTimeLocationID;
                        }

                        break;
                    case MenuOption.SpaceTimeTravel:
                        _gameConsoleView.DisplayGetPlayersNextLocation();
                        break;
                    case MenuOption.SpaceTimeLocationInfo:
                        _gameConsoleView.DisplaySpaceTimeLocations();
                        break;
                    case MenuOption.PlayerInfo:
                        _gameConsoleView.DisplayPlayerInfo();
                        break;
                    case MenuOption.Exit:
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
                Accessable = true
            });
        }

        #endregion
    }
}