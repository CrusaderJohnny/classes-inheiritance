using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;
using System;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Author:Mark Leonardis </remarks>
    /// <remarks>Date: 13/06/24 </remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            Console.WriteLine("Enter the item number of an appliance: ");
            long ap_number;
            bool appNumParce = long.TryParse(Console.ReadLine(), out ap_number);
            while (appNumParce == false)
            {
                Console.WriteLine("Invalid input, try again.");
                appNumParce = long.TryParse(Console.ReadLine(), out ap_number);
            }
            Appliance foundAppliance = null;
            foreach (Appliance appliance in Appliances)
            {
                if (appliance.ItemNumber == ap_number);
                {
                    foundAppliance = appliance;
                    break;
                }
            }
            if (foundAppliance == null)
            {

                Console.WriteLine("No appliances found with that item number.");
            }
            else if (!foundAppliance.IsAvailable)
            {
                Console.WriteLine("Appliance has been checked out.");
                foundAppliance.Checkout();
            }
            else if (foundAppliance.IsAvailable)
            {
                Console.WriteLine("The appliance is not available to be checked out.");
            }
        }
        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            Console.WriteLine("Enter brand to search for:");
            string brand_input = Console.ReadLine();

            List<Appliance> found_appliances = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                if (brand_input == appliance.Brand)
                {
                    found_appliances.Add(appliance);
                }
            }
            DisplayAppliancesFromList(found_appliances, found_appliances.Count);
            if (found_appliances.Count == 0)
            {
                Console.WriteLine("No appliances found.");
            }
        }

        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            Console.WriteLine("Possible options:\n0 - Any\n2 - Double doors\n3 - Three doors\n4 - Four doors\n\nEnter number of doors: ");
            int newDoorNum = 0;
            List<int> door_values = new List<int>();
            door_values.Add(0);
            door_values.Add(2);
            door_values.Add(3);
            door_values.Add(4);
            bool doorParse = int.TryParse(Console.ReadLine(), out newDoorNum);
            while (!doorParse || !door_values.Contains(newDoorNum))
            {
                Console.WriteLine("Incorrect input, please input again.");
                doorParse = int.TryParse(Console.ReadLine(), out newDoorNum);
            }
            List<Appliance> found_appliances = new List<Appliance>();
            foreach (Appliance appliance in Appliances)
            {
                if (Appliance.DetermineApplianceTypeFromItemNumber(appliance.ItemNumber) == Appliance.ApplianceTypes.Refrigerator)
                {
                    Refrigerator fridge = appliance as Refrigerator;
                    if (fridge.Doors == newDoorNum)
                    {
                        found_appliances.Add(appliance);
                    }
                }
            }
            DisplayAppliancesFromList(found_appliances, found_appliances.Count);
        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            Console.WriteLine("Possible options:\n0 - Any\n1 - Residential\n2 - Commercial\nEnter Grade:");
            int vac_num;
            bool valid_vac = int.TryParse(Console.ReadLine(), out vac_num);
            while (!valid_vac || vac_num < 0 || vac_num > 2)
            {
                Console.WriteLine("Error, Invalid Entry");
                valid_vac = int.TryParse(Console.ReadLine(), out vac_num);
            }
            string grade_value = "";
            switch (vac_num)
            {
                case 0:
                    grade_value = "Any";
                    break;
                case 1:
                    grade_value = "Residential";
                    break;
                case 2:
                    grade_value = "Commercial";
                    break;
            }
            int volt;
            Console.WriteLine("Possible options:\n0 - Any\n1 - 18 volt\n2 - 24 volt\nEnter Voltage: ");
            bool valid_volt = int.TryParse(Console.ReadLine(),out volt);
            while (!valid_volt || volt < 0 || volt > 2)
            {
                Console.WriteLine("Error, invalid entry");
                valid_volt = int.TryParse(Console.ReadLine(), out volt);
            }
            short vac_volt = 0;
            switch (volt)
            {
                case 0:
                    vac_volt = 0;
                    break;
                case 1:
                    vac_volt = 18;
                    break; 
                case 2:
                    vac_volt = 24;
                    break;
            }
            List<Appliance> vacuum = new List<Appliance>();
            foreach (Appliance appliance in Appliances)
            {
                if (Appliance.DetermineApplianceTypeFromItemNumber(appliance.ItemNumber) == Appliance.ApplianceTypes.Vacuum)
                {
                    Vacuum vac = appliance as Vacuum;
                    if (grade_value == "Any")
                    {
                        vacuum.Add(appliance);
                    }
                    else if (vac.BatteryVoltage == vac_volt)
                    {
                        vacuum.Add(appliance);
                    }
                }
            }
            DisplayAppliancesFromList(vacuum, vacuum.Count);
        }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            Console.WriteLine("Possible Options:\n0 - Any\n1 - Kitchen\n2 - Work site");
            Console.WriteLine("Enter room type");
            int type_number;
            bool valid_room = int.TryParse(Console.ReadLine(), out type_number);
            while (!valid_room || type_number < 0 || type_number > 2)
            {
                Console.WriteLine("Error, Invalid input");
                valid_room = int.TryParse(Console.ReadLine(), out type_number);
            }
            char room_type = ',';
            switch (type_number)
            {
                case 0:
                    room_type = 'A';
                    break;
                case 1:
                    room_type = 'K';
                    break;
                case 2:
                    room_type = 'W';
                    break;
            }
            List<Appliance> microwave = new List<Appliance>();
            foreach (Appliance appliance in Appliances)
            {
                if (Appliance.DetermineApplianceTypeFromItemNumber(appliance.ItemNumber) == Appliance.ApplianceTypes.Microwave)
                {
                    Microwave micro = appliance as Microwave;
                    if (room_type == 'A')
                    {
                        microwave.Add(micro);
                    }
                    else if (micro.RoomType == room_type)
                    {
                         microwave.Add(micro); 
                    }
                }
            }
            DisplayAppliancesFromList(microwave, microwave.Count);
        }
        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            Console.WriteLine("Possible Options:\n0 - Any\n1 - Quietest\n2 - Quieter\n3 - Quiet\n4 - Moderate");
            Console.WriteLine("Enter sound rating: ");
            int sound_rat;
            bool select_rating = int.TryParse(Console.ReadLine(), out sound_rat);
            while (!select_rating || sound_rat < 0 || sound_rat > 4)
            {
                Console.WriteLine("Invalid option");
                select_rating = int.TryParse(Console.ReadLine(), out sound_rat);
            }
            var sound_rate = "";
            switch (sound_rat)
            {
                case 0:
                    sound_rate = "Any";
                    break;
                case 1:
                    sound_rate = "Qt";
                    break;
                case 2:
                    sound_rate = "Qr";
                    break;
                case 3:
                    sound_rate = "Qu";
                    break;
                case 4:
                    sound_rate = "M";
                    break;
            }
            List<Appliance> dishwashers = new List<Appliance>();
            foreach (Appliance appliance in Appliances)
            {
                if (Appliance.DetermineApplianceTypeFromItemNumber(appliance.ItemNumber) == Appliance.ApplianceTypes.Dishwasher)
                {
                    Dishwasher dis = appliance as Dishwasher;
                    if (sound_rate == "Any")
                    {
                        dishwashers.Add(dis);
                    }
                    else if (dis.SoundRating == sound_rate)
                    {
                        dishwashers.Add(dis);
                    }
                }
            }
            DisplayAppliancesFromList(dishwashers, dishwashers.Count);
        }
        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            Console.WriteLine("Appliance Types\n1 - Refrigerators\n2 - Vacuums\n3 - Microwaves\n4 - Dishwashers");
            Console.WriteLine("Enter type of appliance: ");
            int selectNumber;
            bool selectParse = int.TryParse(Console.ReadLine(), out selectNumber);
            while (!selectParse || selectNumber < 0 || selectNumber > 4) 
            {
                Console.WriteLine("Error, Enter a valid number");
                selectParse = int.TryParse(Console.ReadLine(), out selectNumber);
            }
            Console.WriteLine("Enter number of appliances: ");
            int appNumber;
            bool numberParse = int.TryParse(Console.ReadLine(), out appNumber);
            while (!numberParse || appNumber < 0 )
            {
                Console.WriteLine("Error, Enter a valid number:");
                numberParse = int.TryParse(Console.ReadLine(), out appNumber);
            }
            List<Appliance> randomList = new List<Appliance>();
            foreach (Appliance appliance in Appliances)
            {
                if (selectNumber == 0)
                {
                    randomList.Add(appliance);
                }
                else if (selectNumber == 1)
                {
                    if (Appliance.DetermineApplianceTypeFromItemNumber(appliance.ItemNumber) == Appliance.ApplianceTypes.Refrigerator)
                    {
                        randomList.Add(appliance);
                    }
                }
                else if (selectNumber == 2)
                {
                    if (Appliance.DetermineApplianceTypeFromItemNumber(appliance.ItemNumber) == Appliance.ApplianceTypes.Vacuum)
                    {
                        randomList.Add(appliance); 
                    }
                }
                else if (selectNumber == 3)
                {
                    if (Appliance.DetermineApplianceTypeFromItemNumber(appliance.ItemNumber) == Appliance.ApplianceTypes.Microwave)
                    {
                        randomList.Add(appliance);
                    }
                }
                else if (selectNumber == 4)
                {
                    if (Appliance.DetermineApplianceTypeFromItemNumber(appliance.ItemNumber) == Appliance.ApplianceTypes.Dishwasher)
                    {
                        randomList.Add(appliance);
                    }
                }
            }
            randomList.Sort(new RandomComparer());
            DisplayAppliancesFromList(randomList, appNumber);
        }
    }
}
