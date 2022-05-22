using System;
using static System.Console;

namespace Laboratorna7
{
    class Date
    {
        private int year;
        private string month;
        private int day;
        private DateTime date;

        private static string[] Months = { "january", "february", "march", "april", "may", "june", "july", "august", "september", "october", "november", "december" };
        public static string getMonth(int monthNumber) => Months[monthNumber - 1];
        override public bool Equals(Object? obj)
        {
            if (obj == null || !(obj is Date)) return false;
            return date.Equals(((Date)obj).date);
        }

        public Date(int year, string month, int day)
        {
            this.year = year;
            this.month = month.Trim().ToLower();
            this.day = day;
            int monthNumber = resolveMonth(this.month);
            date = new DateTime(year, monthNumber, day);
        }

        private Date(DateTime date)
        {
            this.date = date;
            year = date.Year;
            month = resolveMonth(date.Month);
            day = date.Day;
        }

        private static int resolveMonth(string month)
        {
            for (int i = 0; i < 12; i++)
            {
                if (Months[i].Equals(month))
                {
                    return i + 1;
                }
            }
            throw new ArgumentException($"Invalid name of month: {month}");
        }

        private static string resolveMonth(int month)
        {
            if (month <= 12 && month > 0) return Months[month - 1];
            throw new ArgumentException($"Invalid number of month: {month}");
        }
        public int getYear() => year;
        public string getMonth() => month;
        public int getDay() => day;

        public int getCode() => year * 1000 + date.Month * 12 + day;

        public Date addDays(int days) => new Date(date.AddDays(days));

        public bool isAfter(Date otherDate) => date > otherDate.date;

        override public string ToString() => $"'{day} {month} {year}'";
    }
    class Value
    {
        private string mainGuestName;
        private int numberOfGuests;
        private string roomType;
        private Date dateOfArrival;
        private int numberOfNights;

        public Value(string mainGuestName, int numberOfGuests, string roomType, Date dateOfArrival, int numberOfNights)
        {
            if (numberOfNights < 1)
            {
                throw new ArgumentException($"Number of nights can't be less then 1: {numberOfNights}");
            }
            if (numberOfGuests < 1)
            {
                throw new ArgumentException($"Number of nights can't be less then 1: {numberOfGuests}");
            }
            this.mainGuestName = mainGuestName;
            this.numberOfGuests = numberOfGuests;
            this.roomType = roomType;
            this.dateOfArrival = dateOfArrival;
            this.numberOfNights = numberOfNights;
        }

        public string getMainGuestName() => mainGuestName;
        public int getNumberOfGuests() => numberOfGuests;
        public string getRoomType() => roomType;
        public Date getDateOfArrival() => dateOfArrival;
        public int getNumberOfNights() => numberOfNights;
        override public string ToString() => $"Guest {mainGuestName} arrives at {dateOfArrival} for {numberOfNights} nights. {numberOfGuests} guests. Room '{roomType}'";

    }

    class Key
    {
        private int bookingCode;
        public Key(int bookingCode)
        {
            this.bookingCode = bookingCode;
        }
        override public bool Equals(Object? obj)
        {
            if (obj == null || !(obj is Key)) return false;
            return bookingCode == ((Key)obj).bookingCode;
        }
        public int getBookinCode() => bookingCode;

        public override string ToString() => $"{bookingCode}";
    }

    class Entry<K, V>
    {
        private K key;
        private V value;

        public Entry(K key, V value)
        {
            this.key = key;
            this.value = value;
        }
        public K getKey() => key;
        public V getValue() => value;

        public override string ToString() => $"{key} --> {value}";
    }

    abstract class Hashtable<K, V>
        where K : class
        where V : class
    {
        protected Entry<K, V>[] table;
        private int size;
        private int capacityIndex;
        private int limit;
        protected int capacity;

        private static int[] CAPACITY = { 7, 13, 29, 59, 127, 251, 509, 1013, 2039, 4093, 8191, 16369, 32797, 65537, 131231 };
        private static int STEP = 5;

        protected static Entry<K, V> DELETED = new Entry<K, V>(null, null);
        public Hashtable()
        {
            capacityIndex = 0;
            initialize();
        }

        private void initialize()
        {
            capacity = CAPACITY[capacityIndex];
            limit = capacity / 2;
            table = new Entry<K, V>[capacity];
            size = 0;
        }

        public void insertEntry(K key, V value)
        {
            Entry<K, V> entry = new Entry<K, V>(key, value);
            int hash = getHash(key);
            if (size > limit)
            {
                WriteLine($"...hashtable reached limit of entries {limit} and will be rehashing before entering new entry");
                rehasing();
                hash = getHash(key);
            }
            table[hash] = entry;
        }

        private void insertEntry(Entry<K, V> entry)
        {
            int hash = getHash(entry.getKey());
            table[hash] = entry;
        }

        public void removeEntry(K key)
        {
            int code = hashCode(key);
            int step = getStep(code);
            int hash = code % capacity;
            while (table[hash] != null)
            {
                if (table[hash].getKey().Equals(key))
                {
                    table[hash] = DELETED;
                    size--;
                    return;
                }
                hash = (hash + step) % capacity;
            }
        }

        public V findValue(K key)
        {
            int code = hashCode(key);
            int step = getStep(code);
            int hash = code % capacity;
            while (table[hash] != null)
            {
                if (table[hash].getKey().Equals(key))
                {
                    return table[hash].getValue();
                }
                hash = (hash + step) % capacity;
            }
            return null;
        }

        private void rehasing()
        {
            Entry<K, V>[] oldTable = table;
            capacityIndex++;
            initialize();
            foreach (Entry<K, V> entry in oldTable)
            {
                if (entry != null && entry != DELETED)
                {
                    insertEntry(entry);
                }
            }
        }

        protected abstract int hashCode(K key);

        private int getHash(K key)
        {
            int code = hashCode(key);
            int step = getStep(code);
            int deleted = -1;   // initially we don't find any DELETED cell
            int hash = code % capacity;
            while (table[hash] != null)
            {
                if (table[hash].getKey().Equals(key))
                {
                    return hash;
                }
                if (deleted == -1 && table[hash] == DELETED)
                {
                    deleted = hash;
                }
                hash = (hash + step) % capacity;
            }
            size++;
            return deleted != -1 ? deleted : hash;
        }

        private int getStep(int code) => code % STEP + 1;

        virtual public void print()
        {
            WriteLine($"size: {size} capacity: {capacity} loadness: { ((double)size) / capacity }");
            for (int i = 0; i < capacity; i++)
            {
                if (table[i] != null)
                {
                    if (table[i] != DELETED)
                    {
                        WriteLine($"\t{i}: {table[i]}");
                    }
                    else
                    {
                        WriteLine($"\t{i}: DELETED");
                    }
                }
                else
                {
                    WriteLine($"\t{i}: null");
                }
            }
        }

        public V[] getValues()
        {
            V[] values = new V[size];
            int i = 0;
            foreach (Entry<K, V> entry in table)
            {
                if (entry != null && entry != DELETED)
                {
                    values[i++] = entry.getValue();
                }
            }
            return values;
        }

        public void clear()
        {
            capacityIndex = 0;
            initialize();
        }

    }

    class Departure
    {
        private Key key;
        private string mainGuestName;
        private string roomType;
        public Departure(Key key, string mainGuestName, string roomType)
        {
            this.key = key;
            this.mainGuestName = mainGuestName;
            this.roomType = roomType;
        }
        public Key getKey() => key;
        public string getMainGuestName() => mainGuestName;
        public string getRoomType() => roomType;
        override public string ToString() => $"Booking {key}. Guest {mainGuestName}. Room '{roomType}'";
    }

    class Departures
    {
        class DayDepaturesTable : Hashtable<Key, Departure>
        {
            protected override int hashCode(Key key) => key.getBookinCode();
        }

        DayDepaturesTable departures;
        public Departures(Departure first)
        {
            departures = new DayDepaturesTable();
            departures.insertEntry(first.getKey(), first);
        }
        public void add(Departure departure) => departures.insertEntry(departure.getKey(), departure);
        public void remove(Departure departure) => departures.removeEntry(departure.getKey());

        public override string ToString()
        {
            Departure[] values = departures.getValues();
            string result = "[ ";
            foreach (Departure departure in values)
            {
                result += $"( {departure} ) ";
            }
            result += "]";
            return result;
        }
        public Departure[] values() => departures.getValues();
    }

    class HotelTable : Hashtable<Key, Value>
    {
        protected override int hashCode(Key key) => key.getBookinCode();
        override public void print()
        {
            WriteLine("--------------------------------Hotel Hash Table:-------------------------------");
            base.print();
        }
    }

    class DeparturesTable : Hashtable<Date, Departures>
    {
        protected override int hashCode(Date key) => key.getCode();
        override public void print()
        {
            WriteLine("----------------------------- Departures Hash Table: ---------------------------");
            base.print();
        }
    }
    public class Program
    {
        static Entry<Key, Value>[] example = {
            new Entry<Key, Value>(new Key(1008), new Value("Sherlock Holmes", 2, "lux", new Date(2022, "May", 12), 5)),
            new Entry<Key, Value>(new Key(1015), new Value("John Watson", 3, "double", new Date(2022, "July", 31), 45)),
            new Entry<Key, Value>(new Key(1022), new Value("Mary Watson", 1, "single", new Date(2022, "September", 1), 3)),
            new Entry<Key, Value>(new Key(1100), new Value("Aaaaa Aaaaaaaa", 1, "single", new Date(2022, "December", 7), 10)),
            new Entry<Key, Value>(new Key(1001), new Value("Bbbb Bbbbbbbb", 4, "lux", new Date(2022, "October", 19), 1)),
            new Entry<Key, Value>(new Key(1555), new Value("Cccc Ccccccc", 2, "double", new Date(2022, "May", 4), 13)),
            new Entry<Key, Value>(new Key(1087), new Value("Dddd Dddddddddd", 6, "lux", new Date(2022, "January", 31), 5))
        };

        static HotelTable bookingTable = new HotelTable();
        static DeparturesTable departuresTable = new DeparturesTable();
        static Random random = new Random();
        static string[] RoomTypes = { "lux", "double", "single", "aprtments", "royal", "econom" };
        static void Main(String[] args)
        {
            WriteLine("Hotel booking");
            string commnad = "help";
            while (commnad != "exit")
            {
                switch (commnad)
                {
                    case "help":
                        onHelp();
                        break;
                    case "example":
                        onExample();
                        break;
                    case "clear":
                        clearTables();
                        break;
                    case "show":
                        onShow();
                        break;
                    case "add":
                        onAdd();
                        break;
                    case "remove":
                        onRemove();
                        break;
                    case "departure":
                        onDeparture();
                        break;
                    case "exit":
                        break;
                    default:
                        onDefault();
                        break;
                }
                Write("> ");
                commnad = ReadLine().Trim().ToLower();
            }
        }

        static int findRoomType(string typeName)
        {
            for (int i = 0; i < RoomTypes.Length; i++)
            {
                if (RoomTypes[i].Equals(typeName)) return i;
            }
            throw new Exception("invalid room type");
        }

        static void onHelp()
        {
            WriteLine(@"Possible commands:
    'example' - clear table and then fill it with example entries
    'clear' - clear table
    'show' - show the current state of the table
    'add' - add new entry
    'remove' - remove entry with specified key
    'departure' - get the list of departures at specified date
    'help' - show possible commnads
    'exit' - exit from the program");
        }

        static void onExample()
        {
            clearTables();
            foreach (Entry<Key, Value> entry in example)
            {
                addBooking(entry.getKey(), entry.getValue());
            }
        }

        static void onShow()
        {
            bookingTable.print();
            departuresTable.print();
        }

        static void onAdd()
        {
            try
            {
                Write("booking code (empty string for random value) > ");
                string bookingCodeStr = ReadLine().Trim();
                int bookingCode = (bookingCodeStr == "") ? random.Next(1000, 2000) : Int32.Parse(bookingCodeStr);
                if (bookingCode < 1000)
                {
                    throw new Exception("booking code can't be less then 1000");
                }

                Write("name of main guest (empty string for Incognito) > ");
                string mainGuestName = ReadLine().Trim();
                if (mainGuestName == "")
                {
                    mainGuestName = "Incognito";
                }

                Write("number of guests (empty string for random value) > ");
                string numberOfGuestsStr = ReadLine().Trim();
                int numberOfGuests = (numberOfGuestsStr == "") ? random.Next(1, 10) : Int32.Parse(numberOfGuestsStr);
                if (numberOfGuests < 1)
                {
                    throw new Exception("number of guests can't be less than 1");
                }

                Write("type of room (empty string for random value) > ");
                string roomType = ReadLine().Trim();
                if (roomType == "")
                {
                    roomType = RoomTypes[random.Next(0, RoomTypes.Length)];
                }
                else
                {
                    findRoomType(roomType);
                }

                Write("date of arrival like '13 december 2022' (empty string for random value) > ");
                string dateOfArrivalStr = ReadLine().Trim();
                int day;
                string month;
                int year;
                if (dateOfArrivalStr == "")
                {
                    day = random.Next(1, 28);
                    month = Date.getMonth(random.Next(1, 12));
                    year = random.Next(1990, 2100);
                }
                else
                {
                    string[] parts = dateOfArrivalStr.Split(' ');
                    if (parts.Length != 3)
                    {
                        throw new Exception("invalid date");
                    }
                    day = Int32.Parse(parts[0]);
                    month = parts[1];
                    year = Int32.Parse(parts[2]);
                }
                Date dateOfArrival = new Date(year, month, day);

                Write("number of nights (empty string for random value) > ");
                string numberOfNightsStr = ReadLine().Trim();
                int numberOfNights = (numberOfNightsStr == "") ? random.Next(1, 10) : Int32.Parse(numberOfNightsStr);
                if (numberOfNights < 1)
                {
                    throw new Exception("number of nights can't be less than 1");
                }

                Key key = new Key(bookingCode);
                Value value = new Value(mainGuestName, numberOfGuests, roomType, dateOfArrival, numberOfNights);
                addBooking(key, value);
                WriteLine($"...added: {key} --> {value}");
            }
            catch (Exception ex)
            {
                WriteLine($"An exeption occured while booking data was being entered: {ex.Message}");
            }
        }

        static void onRemove()
        {
            try
            {
                Write("removing booking code > ");
                string bookingCodeStr = ReadLine().Trim();
                int bookingCode = Int32.Parse(bookingCodeStr);

                removeBooking(bookingCode);
            }
            catch (Exception ex)
            {
                WriteLine($"An exeption occured while booking data was being entered: {ex.Message}");
            }
        }

        static void onDeparture()
        {
            Write("date of departure like '13 december 2022' > ");
            string dateOfDepartureStr = ReadLine().Trim();
            int day;
            string month;
            int year;
            string[] parts = dateOfDepartureStr.Split(' ');
            if (parts.Length != 3)
            {
                throw new Exception("invalid date");
            }
            day = Int32.Parse(parts[0]);
            month = parts[1];
            year = Int32.Parse(parts[2]);
            Date dateOfDeparture = new Date(year, month, day);
            Departure[] departures = allDeparturesAtThisDate(dateOfDeparture);
            if (departures.Length == 0)
            {
                WriteLine($"Departures at {dateOfDeparture} are not found");
            }
            else
            {
                WriteLine($"At {dateOfDeparture} there are departures:");
                foreach (Departure departure in departures)
                {
                    WriteLine($"\t{departure}");
                }
            }
        }

        static void onDefault()
        {
            WriteLine("Invalid command. Please input valid commnad. You can see list of all commnads by commnad 'help'");
        }

        static void clearTables()
        {
            bookingTable.clear();
            departuresTable.clear();
        }

        static void addBooking(Key key, Value value)
        {
            bookingTable.insertEntry(key, value);
            Departure departure = new Departure(key, value.getMainGuestName(), value.getRoomType());
            Date dayDeparture = value.getDateOfArrival().addDays(value.getNumberOfNights());
            Departures departures = departuresTable.findValue(dayDeparture);
            if (departures != null)
            {
                departures.add(departure);
            }
            else
            {
                departuresTable.insertEntry(dayDeparture, new Departures(departure));
            }
        }

        static void removeBooking(int bookingCode)
        {
            Key key = new Key(bookingCode);
            Value value = bookingTable.findValue(key);
            if (value == null)
            {
                WriteLine($"Value by key {bookingCode} is not found");
                return;
            }
            bookingTable.removeEntry(key);
            Departure departure = new Departure(key, value.getMainGuestName(), value.getRoomType());
            Date dayDeparture = value.getDateOfArrival().addDays(value.getNumberOfNights());
            Departures departures = departuresTable.findValue(dayDeparture);
            if (departures != null)
            {
                departures.remove(departure);
                WriteLine($"...removed: {key} --> {value}");
            }
            else
            {
                throw new Exception($"Departure not found: {dayDeparture} --> {departure}");
            }
        }

        static Departure[] allDeparturesAtThisDate(Date dateOfDeparture)
        {
            Departures departures = departuresTable.findValue(dateOfDeparture);
            if (departures != null)
            {
                return departures.values();
            }
            else
            {
                return new Departure[0];
            }
        }
    }
}