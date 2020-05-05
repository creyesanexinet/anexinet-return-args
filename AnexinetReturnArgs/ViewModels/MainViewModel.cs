using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AnexinetReturnArgs.Entities;
using AnexinetReturnArgs.Enums;
using AnexinetReturnArgs.Helpers;
using AnexinetReturnArgs.Models;
using Xamarin.Forms;

namespace AnexinetReturnArgs.ViewModels
{
    /// <summary>
    /// Main view model
    /// </summary>
    public class MainViewModel: BaseViewModel
    {
        /// <summary>
        /// String as return argument
        /// </summary>
        private string _stringReturn;

        /// <summary>
        /// String return command
        /// </summary>
        private ICommand StringReturnCommand;

        /// <summary>
        /// Car entity as return argument
        /// </summary>
        private ObservableCollection<CarEntity> _cars; 

        /// <summary>
        /// Main view model
        /// </summary>
        public MainViewModel()
        {
            
        }

        /// <summary>
        /// Gets or sets the selected type option.
        /// </summary>
        /// <value>The selected type option.</value>
        public string StringReturn
        {
            get { return _stringReturn; }
            set
            {
                if (_stringReturn != value)
                {
                    _stringReturn = value;
                    OnPropertyChanged(nameof(StringReturn));
                }
            }
        }

        /// <summary>
        /// On string return command
        /// </summary>
        public Command OnStringReturnCommand
        {
            get
            {
                return new Command(() => DisplayString());
            }
        }

        /// <summary>
        /// On string return command
        /// </summary>
        public Command OnCarsReturnCommand
        {
            get
            {
                return new Command(() => DisplayCars());
            }
        }

        /// <summary>
        /// Displays string
        /// </summary>
        private void DisplayString()
        {
            ReturnArguments returnArguments = GetMyString();
            StringReturn = returnArguments.Value.ToString();
        }

        /// <summary>
        /// Displays string
        /// </summary>
        private void DisplayCars()
        {
            ReturnArguments returnArguments = GetCars();
            Cars = (ObservableCollection<CarEntity>)returnArguments.Value;
        }

        /// <summary>
        /// Get my string
        /// </summary>
        /// <returns>String</returns>
        private ReturnArguments GetMyString()
        {
            ReturnArguments returnArguments = new ReturnArguments();

            try
            {
                returnArguments.Value = "My string";

                return returnArguments;
            }
            catch(Exception ex)
            {
                returnArguments.Value = string.Empty;
                returnArguments.Message = String.Format("{0} {1}", ex.InnerException, ex.Message);

                Dictionary<string, string> logData = new Dictionary<string, string>();
                logData.Add("Fails", "Sending the string 'My string'");

                ReturnArgumentsTracingModel returnArgumentsTracingModel = new ReturnArgumentsTracingModel()
                {
                    UserId = "1",
                    EventName = "user_action",
                    ScreenName = "MainPage",
                    ActionType = "Button",
                    ActionName = "GetMyString",
                    LogData = logData,
                    Exception = ex
                };

                returnArguments.TraceWithFirebase(returnArgumentsTracingModel);

                return returnArguments;
            }
        }

        /// <summary>
        /// A observable collection for cars entity
        /// </summary>
        /// <value>Cars collection</value>
        public ObservableCollection<CarEntity> Cars
        {
            get
            {
                return _cars;
            }
            set
            {
                if (_cars != value)
                {
                    _cars = value;
                    OnPropertyChanged(nameof(Cars));
                }
            }
        }

        /// <summary>
        /// Get my string
        /// </summary>
        /// <returns>String</returns>
        private ReturnArguments GetCars()
        {
            ReturnArguments returnArguments = new ReturnArguments();

            try
            {
                // Some external resources
                ObservableCollection<CarEntity> carEntities = new ObservableCollection<CarEntity>()
                {
                    new CarEntity(){ Id = "55a6e9ec-11db-4f63-9d28-b50dcb147365", Maker = "Ford", Model = "EcoSport", Year = "2020" }
                };

                /// Producing error
                carEntities[2].Year = "2020";

                returnArguments.Value = carEntities;

                return returnArguments;
            }
            catch (Exception ex)
            {
                returnArguments.Value = new ObservableCollection<CarEntity>();
                returnArguments.Message = String.Format("{0} {1}", ex.InnerException, ex.Message);

                Dictionary<string, string> logData = new Dictionary<string, string>();
                logData.Add("Fails", "Sending cars");

                ReturnArgumentsTracingModel returnArgumentsTracingModel = new ReturnArgumentsTracingModel()
                {
                    UserId = "1",
                    EventName = "user_action",
                    ScreenName = "MainPage",
                    ActionType = "Button",
                    ActionName = "GettingCars",
                    LogData = logData,
                    Exception = ex
                };

                returnArguments.TraceWithFirebase(returnArgumentsTracingModel);

                return returnArguments;
            }
        }
    }
}
