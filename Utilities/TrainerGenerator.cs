using System;
using System.Collections.Generic;
using System.IO;

namespace SearchingSortingPagination.Utilities
{
    public class TrainerGenerator
    {
        public Random Rand { get; private set; }
        public TrainerGenerator()
        {
            Rand = new Random();
        }
        public static string[] Fields { get; private set; } = 
        {
            "Logic", "Mathematics", "Statistics", "Systems Theory", "Decision Theory", "Computer Science",
            "Physics", "Chemistry", "Earth Science", "Astronomy", "Biochemistry", "Microbiology", 
            "Botany", "Zoology", "Ecology", "Sociology", "Psychology", "Medicine", "Economics"
        };
        public List<Tuple<string, string>> GetFullNames(int number)
        {
            string[] firstnames = { "Gustavo", "Sheena", "Henry", "Claudia", "Yvonne", "Priscilla", "Scot", "Curtis", "Joan", "Lanna", "Yoichiro", "Arif", "Isabel", "Marlin", "Jeffrey", "Forrest", "Christinia", "Gerrit", "Albert", "Michele", "Shelly", "Ana", "Mae", "Ivan", "Kari", "Leah", "Vincent", "Helen", "Reed", "Ranjit", "Adam", "Anna", "Dwayne", "Bharat", "Alfredo", "Maxwell", "Baris", "R. Morgan", "Jian Shuo", "Ronald", "Troy", "Cathan", "Mosha", "Nieves", "Qiang", "Mallory", "Della", "Mikael", "H.", "Don", "Julio", "Kelli", "Chelsea", "Arno", "Elijah", "Lee", "Alison", "Pilar", "Kayla", "Deborah", "JoLynn", "Kathie", "Fernando", "Tristan", "Cynthia", "Carol Ann", "Guy", "Payton", "Stu", "Ashvini", "Gavin", "Rafael", "Shelley", "Alejandro", "Judith", "Tete", "Filomena", "Devin", "Brianna", "Micheal", "Stefanie", "Nuan", "Merav", "Jenna", "Joy", "Walter", "Lori", "Sariya", "Irving", "Michiel", "Kim", "Ethan", "Summer", "Eli", "Annette", "Gretchen", "Leslie", "Edna", "Kristopher", "Tai", "Takiko", "Tish", "Amir", "Dora", "Lucas", "Taylor", "Wendy", "Gilbert", "Nellie", "Hazem", "Joseph", "Regina", "Briana", "Shaun", "Marc", "Leonard", "Sootha", "Ed", "Liam", "Wilson", "Melody", "Karl", "Jun", "Betsy", "Courtney", "Christian", "Hector", "Kaitlin", "Nitin", "Manoj", "Cara", "Jeanette", "Tamer", "Mason", "Ty Loren", "Luca", "Zachary", "Christy", "Balaganesan", "Daniel", "Austin", "Victor", "Mackenzie", "Lucy", "Meredith", "Adrienne", "Pablo", "Amanda", "Renee", "Ebony", "Renée", "Carly", "Shay", "Vassar", "Sandeep", "Tengiz", "Bridgette", "Faith", "Madeline", "Reginald", "Yolanda", "Mete", "Yuhong", "Stuart", "Gabe", "Makayla", "Ramón", "Suzanne", "Ramon", "Tsvi", "Timothy", "Frank", "Edwin", "Cassandra", "Ronnie", "Zoe", "Steve", "Paulo", "Linda", "Bethany", "Michael John", "Y.", "Jordan", "Andy", "Jorge", "Lucio", "Denean", "Wanda", "Joanna", "Mario", "Bryan", "Ciam", "Liza Marie", "Angel", "Dale", "Donna", "Tamara", "Dan", "Kerim", "Fred", "Jasmine", "Krista", "Mitchell", "Emmanuel", "Jeremiah", "Rohinton", "Tanya", "Mariah", "Whitney", "Yao-Qiang", "Joyce", "Isabelle", "Brandy", "Melissa", "Dustin", "Christina", "Abe", "Rebekah", "Clifford", "Virginia", "Kirk", "Rajesh", "Michael", "Sandra", "Jeffery", "Mandy", "Peggy", "A. Scott", "Milton", "Dirk", "Chloe", "Gail", "Hannah", "Sidney", "Kelsey", "Margaret", "Jodan", "Dianne", "Brittany", "Lance", "Lydia", "Sylvia", "Cristian", "Houman", "Pearlie", "Diana", "Candice", "Gary", "Candy", "George", "Alice", "Stefen", "Bobby", "Tad", "Patrick", "Connie", "Toby", "Leota", "Johnathan", "June", "Lorrin", "Carlos", "Shane", "Janaina Barreiro Gambaro", "Erica", "Monica", "Brittney", "Crystal", "Maria", "Ricky", "Andre", "María", "Clair", "Sriniwa", "Ioannis", "Geri", "James", "Johnny", "Ricardo", "Glin", "Irma", "Carina", "Nigel", "Stacy", "Debra", "Jerry", "Erick", "K.", "Megan", "Janaina", "Jauna", "Kern", "Duane", "Sylvester", "Geraldine", "Kristen", "Bruno", "Bart", "Adina", "Luis", "Clinton", "Dana", "Louis", "Derik", "Kris", "Tawana", "Margie", "Nina", "Veronica", "Alexandre", "Kaitlyn", "Jacob", "Tara", "Gabriele", "Aldeen", "Stacie", "Christie", "Kaylee", "Alexia", "Darrell", "Denise", "Jimmy", "Roberto", "Jaclyn", "Conor", "Thierry", "Carole", "Joel", "Douglas", "Kellie", "Zheng", "Jyothi", "Celine", "Jodi", "Erin", "Sebastian", "Ido", "Alan", "Ernest", "Denis", "Reinout", "Angelica", "Riley", "Sarah", "Kristine", "Vance", "Ben", "Aidan", "Destiny", "Brannon", "Jada", "Mark", "Franklin", "Edward", "Kyle", "Kyley", "Dennis", "Brendan", "Chad", "Pat", "Anita", "Jocelyn", "Manuel", "Tiffany", "Rose", "Rostislav", "Joe", "Javier", "Ann", "Mitch", "Vamsi", "Fukiko", "Lindsay", "Candace", "Katelyn", "Marvin", "Brenda", "Misty", "Kok-Ho", "Meghan", "Erika", "Stanley", "Karla", "Katrina", "Pamela", "Adriana", "Alexa", "Bianca", "Jackson", "Lili", "Nancy", "Masaki", "Sydney", "Theodore", "Dominic", "Hazel", "Shu", "Olga", "Stephen", "Mindy", "Rhoda", "Mihail", "Justine", "Hung-Fu", "Arthur", "Emilio", "Levi", "Jossef", "Ken", "Silvia", "Alexandra", "Alberto", "Billie Jo", "Damon", "Norimichi", "Rachel", "Jon", "Jarrod", "Jean", "Suzana De Abreu", "Muniraju", "Nate", "Eduardo", "Frances", "Kathryn", "Heidi", "Raul", "Darryl", "Martin", "Mohamed", "Ethel", "Prasanna", "Homer", "Brett", "Bev", "Karan", "Mahesh", "Lolan", "Stefano", "Lionel", "Morgan", "Marie", "Max", "Juanita", "Clay", "Kelly", "Ryan", "Shelby", "Dick", "Arvind", "Humberto", "Robyn", "Warren", "Nicholas", "Yiroyuki", "Krishna", "Logan", "Lacey", "Pamala", "Jose", "Lisa", "José", "Helge", "Elsa", "Judy", "Sairaj", "Ashley", "Teresa", "Terri", "Mary Lou", "Sam", "Naomi", "Derek", "Willie", "Harold", "Stacey", "Sethu", "Allison", "Arianna", "Elizabeth", "Andrés", "Ashlee", "Andres", "Ciro", "Micah", "Donals", "Sean", "Brian", "Casey", "Derrick", "Felicia", "Tom", "Jinghao", "Pieter", "Nelson", "Chris", "Garrett", "Fran", "Hao", "Lola", "Magnus", "Cathy", "Annik", "Florian", "Alvin", "Cory", "Juan", "Josh", "Andreas", "Britta", "Evan", "Audrey", "Mike", "Kathy", "Merrill", "Kevin", "Jamie", "Janet", "Kristi", "Kenneth", "Twanna", "Tomas", "Antonio", "Paula", "Latoya", "Anton", "Liz", "Reuben", "Michiko", "Florence", "Cheryl", "Sierra", "Melinda", "Lindsey", "Abby", "Alma", "Sophia", "Brent", "Jim", "Neal", "Masato", "Bonnie", "Bryce", "Holly", "Trinity", "Caroline", "Jessica", "Cornett", "Robertson", "Ruben", "April", "Clarence", "Tyler", "Terrance", "Selena", "Kristin", "Sabria", "Corinna", "Parul", "Neva", "Cecilia", "Bjorn", "Giraldo", "Kelvin", "Gregory", "Bridget", "Tonya", "Marshall", "Carmen", "Cornelius", "Pete", "Wei", "Matthew", "Tina", "Phillip", "Karel", "Marcia", "Eunice", "Francis", "Roy", "Ross", "Jade", "Blaine", "Deepak", "Alexis", "Tasha", "Bryant", "Jian", "J. Phillip", "Carolee", "Shirley", "Claire", "Jay", "Trisha", "Yan", "Arvid", "Miguel", "Kristy", "Keith", "Kristina", "Prashanth", "Lowell", "Enoch", "Ariana", "Dorothy", "Lenore", "Rachael", "Sue", "Marissa", "Angela", "Eddie", "Ajay", "Gladys", "Becky", "Jake", "Jovita", "Imtiaz", "Abraham", "Olinda", "Grant", "Cesar", "César", "Sheila", "Colin", "Shawna", "Eric", "Pei", "Carla", "Caleb", "Danny", "Scott", "Kendall", "Jerome", "Nino", "Melanie", "Carl", "Alexander", "Jermaine", "Rosa", "Jane", "Stephanie", "Benjamin", "Tony", "Randy", "Bronson", "Maurice", "Kitti", "Jeremy", "Rebecca", "Kara", "Gytis", "Lester", "Laura", "Bruce", "Jessie", "Christine", "Doris", "Darren", "Lawrence", "Bradley", "Dakota", "Jacquelyn", "Erik", "Frederick", "Simon", "Giorgio", "Ole", "Marian", "Calvin", "Corey", "Karen", "Alvaro", "Jae", "Abigail", "Gina", "Jillian", "Jarred", "Betty", "Cristina", "Allen", "Donald", "Meagan", "Aimee", "Shish", "Blake", "Tim", "Marcel", "Syed", "Hunter", "Kendra", "Nikki", "Ruby Sue", "Brandon", "Daisy", "Philip", "Nathaniel", "Alyssa", "Barbara", "Grace", "Armando", "Rodney", "Omar", "Vanessa", "Jeff", "Haley", "Beverly", "Edgar", "Desiree", "Natasha", "Desirée", "Craig", "Terry", "Connor", "Natalie", "Pam", "Cedric", "Ralph", "Nicky", "Bernard", "Maurizio", "Elena", "Phyllis", "Larry", "Norma", "Shyamalan", "Shanay", "Isaac", "Tracy", "Raman", "Patricia", "Waleed", "Begoña", "Raquel", "Madalena", "Oscar", "Jill", "Theresa", "Deb", "Fadi", "Gabrielle", "Ian", "Jennifer", "Alisha", "Drew", "Melvin", "Janeth", "Vivian", "Andrea", "Yale", "Sara", "Brooke", "Vadim", "Rossane", "Mary", "Jonathon", "Neil", "Tabitha", "Colleen", "Suchitra", "Esther", "Kerry", "Orlando", "Sharon", "Lane", "Luke", "Greg", "Cameron", "Beth", "Caitlin", "Osarumwense", "Anne", "Robin", "Ingrid", "Lorraine", "Emily", "Samantha", "Clayton", "Carlton", "Hany", "Anders", "Ramona", "Maciej", "Michal", "Paige", "Brandi", "Euan", "Mindaugas", "Raymond", "Jared", "Marcus", "Bob", "Madison", "Valerie", "Elsie", "Vidur", "Hillaine", "Wathalee", "Shawn", "Dawn", "Barry", "Samuel", "Cecil", "Christopher", "Jolie", "Billy", "Alícia", "Alicia", "Krystal", "David", "Wanida", "Cindy", "Suroor", "Shammi", "Bailey", "Katherine", "Miranda", "Jo", "Sameer", "Noah", "Julie", "William", "Hattie", "Lloyd", "Randall", "Marco", "Ted", "Eva", "Gabriel", "Byron", "Mircea", "Hailey", "Emilo", "Mandar", "Abhijit", "Gabriella", "Wyatt", "Alexandria", "Ovidiu", "Wesley", "Michelle", "Ebru", "Robert", "Anthony", "Rob", "Nicole", "Carrie", "Jaime", "Andrew", "Molly", "Rudolph", "Manish", "Marjorie", "Thomas", "Jésus", "Latasha", "Darin", "Aaron", "Cassidy", "Dylan", "Rosmarie", "Julian", "Geoffrey", "Petr", "Xavier", "Cecelia", "Anibal", "Danielle", "Teanna", "Trish", "Phil", "Jason", "Niñia", "Steven", "Autumn", "Susan", "Justin", "Gigi", "Shannon", "Cody", "Glenna", "Salman", "Dragan", "Amy", "Janelle", "Tammy", "Jackie", "Gordon", "Rodrigo", "Anav", "Charlene", "Willis", "Kate", "Evelyn", "Francisco", "Peng", "Hanying", "Birgit", "Pedro", "Roger", "Katie", "Jonathan", "Carolyn", "Peter", "Onetha", "Min", "Sheela", "A.", "Tosh", "Rakesh", "Isaiah", "Jack", "Gloria", "Cassie", "Devon", "Brad", "Marty", "Alex", "Lawrie", "Irene", "Dominique", "Toni", "Dalton", "Olivia", "Arturo", "Jordyn", "Dave", "Martha", "Geoff", "Nathan", "Nichole", "Jenny", "Mayra", "Carol", "Yuping", "Josue", "Eugene", "Garth", "Deena", "Suzann", "Karin", "Russell", "Terrence", "Sergio", "Cole", "DeeDee", "Run", "Richard", "Kurt", "Todd", "Stefan", "Seth", "Lauren", "Kathleen", "John", "Jan", "Ramesh", "Juha-Pekka", "Amber", "Isabella", "Diane", "Shirleen", "Daisuke", "Jesse", "Victoria", "Gerald", "Damien", "Adrian", "Arlene", "Raja", "Punya", "Rolando", "Charles", "Carson", "Preston", "Mari", "Sunil", "Paul", "Mathew", "Janice", "Leo", "Ivo", "Mya", "Sabrina", "Emma", "Joshua", "Ruth", "Belinda", "Wayne", "Kimberly", "Constance", "Ram", "Delia", "Jacqueline", "Tommy", "Glenn", "Jeanie", "Geneva", "Savannah", "Spencer", "Zainal", "Karren", "Kay", "Julia", "Tyrone", "Chase", "Lynn", "François", "Matthias", "Heather", "Grigory", "Trevor", "Deanna", "Monique", "Nicolas", "Gracia", "Catherine", "Brigid", "Nkenge" };
            string[] lastnames = { "Abbas", "Abel", "Abercrombie", "Abolrous", "Acevedo", "Achong", "Ackerman", "Adams", "Adina", "Agbonile", "Agcaoili", "Aguilar", "Ahlering", "Ajenstat", "Akers", "Alameda", "Alan", "Alberts", "Albrecht", "Albright", "Albury", "Alcorn", "Alderson", "Alexander", "Allen", "Allison", "Alonso", "Alpuerto", "Altamirano", "Altman", "Alvarado", "Alvarez", "Alvaro", "Amland", "Anand", "Andersen", "Anderson", "Ansman-Wolfe", "Antrim", "Appelbaum", "Arakawa", "Arbelaez", "Archer", "Arifin", "Armstrong", "Arthur", "Arun", "Ashe", "Ashton", "Atkinson", "Ault", "Avalos", "Ayers", "Bacalzo", "Bacon", "Bailey", "Baker", "Baldwin", "Bales", "Baltazar", "Banack", "Bankert", "Banks", "Barbariol", "Barber", "Barker", "Barley", "Barlow", "Barnes", "Barnhill", "Barr", "Barrera", "Barreto de Mattos", "Bartness", "Barzdukas", "Bashary", "Bates", "Bauer", "Beanston", "Beasley", "Beaver", "Bebbington", "Beck", "Becker", "Beebe", "Bell", "Belli", "Belson", "Bendixen", "Bennett", "Bennetts", "Ben-Sachar", "Benshoof", "Benson", "Bent", "Bentley", "Berch", "Berg", "Berge", "Berger", "Bergin", "Berglund", "Bernacchi", "Berndt", "Berry", "Bhat", "Bidelman", "Billstrom", "Bischoff", "Bishop", "Black", "Blackwell", "Blanco", "Blanton", "Blue", "Blythe", "Bockenkamp", "Bohling", "Bolender", "Bonifaz", "Booth", "Boseman", "Bourne", "Bowen", "Bowman", "Bradley", "Brandon", "Bready", "Breer", "Bremer", "Brewer", "Brian", "Bright", "Brink", "Brooks", "Brown", "Browne", "Browning", "Browqett", "Brumfield", "Brummer", "Brundage", "Bruner", "Brunner", "Bruno", "Bryant", "Buchanan", "Bueno", "Buensalido", "Burke", "Burkhardt", "Burlacu", "Burnell", "Burnett", "Burton", "Buskirk", "Bustamante", "Butler", "Byham", "Byrnes", "Cabello", "Cai", "Calafato", "Caldwell", "Calone", "Camacho", "Camargo", "Cameron", "Campbell", "Campen", "Cannata", "Cannon", "Cantoni", "Canuto", "Cao", "Caprio", "Carey", "Carlisle", "Carlson", "Carmichael", "Carmody", "Carnes", "Caro", "Caron", "Carothers", "Carreras", "Carroll", "Carson", "Carter", "Castellucio", "Castro", "Casts", "Catalano", "Cavallari", "Cavendish", "Cavestany", "Cencini", "Cereghino", "Cetinok", "Chai", "Chambers", "Champion", "Chande", "Chander", "Chandler", "Chandra", "Chapla", "Chapman", "Charncherngkha", "Charney", "Chavez", "Chen", "Cheng", "Chesnut", "Chestnut", "Chisholm", "Choi", "Choin", "Chor", "Chow", "Christensen", "Christie", "Ciccu", "Clark", "Clayton", "Cleary", "Cobb", "Coffman", "Cole", "Coleman", "Collins", "Colon", "Colvin", "Con", "Connelly", "Conner", "Conroy", "Consentino", "Contreras", "Cook", "Cooper", "Core", "Corets", "Coriell", "Cornelsen", "Costa Da Silva", "Cox", "Cracium", "Creasey", "Crow", "Culbertson", "Culp", "Cunningham", "Curry", "Daniels", "Danner", "Danseglio", "Davis", "De Matos Miranda Filho", "De Oliveira", "Dean", "Deborde", "Decker", "DeGrasse", "Delaney", "Dellamore", "Delmarco", "Demicell", "Demott Jr", "Dempsey", "Deng", "Deniut", "Dennis", "Desai", "Desalvo", "Dewer", "D'Hers", "Diaz", "Dickmann", "Dickson", "Dievendorff", "Dillon", "Dixon", "Dobney", "Dockter", "Dodd", "Dominguez", "Donovan", "Doyle", "Drury", "D'sa", "Dudenhoefer", "Duerr", "Duff", "Duffy", "Dulong", "Dumitrascu", "Duncan", "Dusza", "Dyck", "Earls", "Eaton", "Ecoffey", "Edwards", "Eldridge", "Ellerbrock", "Elliott", "Elson", "Emanuel", "Eminhizer", "Emory", "Entin", "Erickson", "Ersan", "Espinoza", "Estes", "Esteves", "Evans", "Faeber", "Fakhouri", "Farino", "Farrell", "Fatima", "Feng", "Fernandez", "Ferrier", "Fine", "Finley", "Fitzgerald", "Flood", "Flores", "Fluegel", "Focht", "Ford", "Fort", "Foster", "Fox", "Frank", "Frazier", "Fredericksen", "French", "Friedland", "Frintu", "Friske", "Frum", "Fuentes Espinosa", "Fulton", "Funk", "Gaffney", "Gage", "Gallagher", "Galos", "Galvin", "Ganio", "Gao", "Garcia", "Garden", "Garza", "Gash", "Gates", "Gee", "Gehring", "Geist", "German", "Getzinger", "Giakoumakis", "Gibbens", "Gibson", "Giglio", "Gilbert", "Gill", "Gilliat", "Gimmi", "Givens", "Glenn", "Glimp", "Glynn", "Gode", "Goel", "Goktepe", "Goldberg", "Goldstein", "Gomez", "Gonzales", "Gonzalez", "Gottfried", "Graff", "Graham", "Grande", "Gray", "Green", "Greer", "Griffin", "Grisso", "Groncki", "Groth", "Gubbels", "Guo", "Gupta", "Gustafson", "Gutierrez", "Guzik", "Haemon", "Hagege", "Hagemann", "Hagens", "Haines", "Hall", "Hamilton", "Hammond", "Hance", "Handley", "Hanif", "Hankin", "Hanson", "Hapke", "Harding", "Harnpadoungsataya", "Harrington", "Harris", "Harrison", "Harteveld", "Hartwig", "Harui", "Hass", "Hassall", "Hasty", "Haugh", "Hay", "Hayes", "He", "Heaney", "Hector", "Hedlund", "Hee", "Heidepriem", "Heloo", "Hendergart", "Henderson", "Hendricks", "Henningsen", "Henshaw", "Hensien", "Herman", "Hernandez", "Herrick", "Herring", "Hesse", "Heymsfield", "Higa", "Higginbotham", "Higgs", "Highfill", "Hill", "Hillmann", "Hines", "Hink", "Hirota", "Hirsch", "Hite", "Hodges", "Hodgson", "Hoeing", "Hoepf", "Hoffman", "Hoganson", "Hohman", "Holliday", "Holloway", "Holm", "Holman", "Holmes", "Holt", "Homer", "Houston", "Howard", "Hows", "Hu", "Huang", "Huckaby", "Huff", "Hughes", "Hummer", "Hunter", "Huntsman", "Hurkett", "Hurt", "Hurtado", "Iallo", "Ihrig", "Inghram", "Ingle", "Irwin", "Isla", "Ismert", "Ison", "Ito", "Iyer", "Jackson", "Jacobs", "Jacobsen", "Jacobson", "Jaffe", "Jai", "James", "Jamison", "Jarvis", "Javier Castrejón", "Jenkins", "Jiang", "Jimenez", "Jiménez", "Johns", "Johnsen", "Johnson", "Johnston", "Jones", "Jordan", "Justice", "Kaffer", "Kahn", "Kaliyath", "Kane", "Kapoor", "Kastner", "Katyal", "Kawai", "Kearney", "Keil", "Keiser", "Kelley", "Kelly", "Kennedy", "Kesslep", "Kesterson", "Keyser", "Khan", "Khanna", "Kharatishvili", "Kim", "King", "Kirilov", "Kitt", "Kleinerman", "Kobylinski", "Koch", "Koduri", "Koenigsbauer", "Kogan", "Komosinski", "Konersmann", "Koski", "Kotc", "Kovar", "Kovár", "Kozlowski", "Kramer", "Krane", "Krapauskas", "Krebs", "Krow", "Krupka", "Kumar", "Kung", "Kuppa", "Kurjan", "Kurniawan", "Kurtz", "Kwok", "Lal", "LaMee", "Lan", "Lang", "Laszlo", "Lauer", "Laursen", "Lawrence", "Lazecky", "Leavitt", "Ledyard", "Lee", "Leitao", "Lenehan", "Lengel", "Leonetti", "Lepro", "Lertpiriyasuwat", "Lesko", "Leste", "Levy", "Lew", "Lewin", "Lewis", "Li", "Liang", "Lin", "Lique", "Lisboa", "Liu", "Lloyd", "Lobao", "Lockert", "Logan", "Loh", "Long", "Looney", "Lopez", "Los", "Louverdis", "Low", "Lu", "Lucerne", "Lugo", "Lum", "Lundahl", "Lunt", "Luo", "Lutes", "Luthra", "Lyeba", "Lynn", "Lyon", "Lysaker", "Ma", "Macagno", "Maccietto", "MacDonald", "Macrae", "Madan", "Magenheimer", "Male", "Malhotra", "Malmendier", "Manchepalli", "Manek", "Manzanares", "Marcovecchio", "Mares", "Margheim", "Markwood", "Marple", "Marshall", "Mart¡nez", "Martin", "Martinez", "Masters", "Matthew", "Matthews", "Maxham", "Maxwell", "Maynard", "Mays", "Mcanich", "McArthur", "McAskill-White", "McCarthy", "McCarty", "McClane", "McCormick", "McCoy", "McDonald", "McGuel", "McGuigan", "McGurk", "McKay", "McLin", "McPhearson", "McSharry Jensen", "Meadows", "Medina", "Mehlert", "Mehta", "Meisner", "Mello", "Mendiola", "Mendoza", "Mensa-Annan", "Meston", "Metters", "Mew", "Meyer", "Meyerhoff", "Meyyappan", "Michaels", "Miksovsky", "Miller", "Mirchandani", "Mitchell", "Mitosinka", "Mitzner", "Moberly", "Moeller", "Mohamed", "Mohan", "Monitor", "Monroe", "Montera", "Moon", "Moore", "Morcos", "Moreland", "Moreno", "Morgan", "Morris", "Moschell", "Moseley", "Moya", "Moyer", "Mu", "Mughal", "Mungin", "Munoz", "Muñoz", "Munson", "Murphy", "Murray", "Myer", "Naik", "Nara", "Narayanan", "Nartker", "Nash", "Nason", "Nath", "Natsuhara", "Navarro", "Nay", "Nayberg", "Nelsen", "Nelson", "Netz", "Newman", "Ngoh", "Nicholls", "Nilson", "Niswonger", "Nixon", "Norman", "Norred", "Northup", "Nusbaum", "O'Brien", "O'Connell", "O'Dell", "O'Donnell", "Ogisu", "O'Hara", "Okada", "Okelberry", "Olguin", "Oliver", "Olivotto", "Orman", "Orona", "Ortega", "Ortiz", "Osada", "Osborn", "Osorio", "Oveson", "Oviatt", "Pai", "Pais", "Pak", "Pal", "Palit", "Park", "Parker", "Parkinson", "Patel", "Pather", "Patten", "Patterson", "Pearson", "Pederson", "Pellow", "Penor", "Penuchot", "Peoples", "Perera", "Perez", "Perko", "Perry", "Petculescu", "Peters", "Peterson", "Pettengill", "Philips", "Phillips", "Piaseczny", "Pike", "Pinkston", "Pinto", "Playstead", "Poe", "Pogulsky", "Poland", "Pollock", "Pompa", "Poorbaugh", "Porter", "Posner", "Posti", "Potts", "Pournasseh", "Powell", "Prasad", "Preston", "Price", "Pritchett", "Ptaszynski", "Pugh", "Pulipalyam", "Purcell", "Quintana", "Raheem", "Rai", "Railson", "Raje", "Raji", "Ralls", "Raman", "Ramirez", "Ramos", "Rana", "Randall", "Rao", "Rapier", "Ray", "Ready", "Reams", "Reátegui Alayo", "Recker", "Rector", "Reding", "Reed", "Reeves", "Reinhart", "Reisner", "Reiter", "Remick", "Remmington", "Rettig", "Reynolds", "Rhodes", "Richards", "Richardson", "Richins", "Richmeier", "Richter", "Riegle", "Rienstra", "Rivas", "Rivera", "Rizaldy", "Rizzi", "Roberts", "Robinett", "Robinson", "Rockne", "Rodgers", "Rodman", "Rodriguez", "Roessler", "Rogers", "Romero", "Rosemont", "Ross", "Rothenberg", "Rothkugel", "Rounthwaite", "Rousey", "Rovira Diez", "Rowe", "Roy", "Rubio", "Ruggiero", "Ruiz", "Rusek", "Rusko", "Russell", "Ruth", "Ryan", "Sabella", "Sacksteder", "Saddow", "Sai", "Salah", "Salanki", "Salavaria", "Salmre", "Sam", "Samant", "Samarawickrama", "Sanchez", "Sánchez", "Sandberg", "Sanders", "Sandidge", "Sandoval", "Sands", "Sandstone", "Sanz", "Sara", "Saraiva", "Saravan", "Sato", "Saunders", "Sawyer", "Sazanovich", "Scardelis", "Schare", "Schleger", "Schmidt", "Schulte", "Schultz", "Scott", "Seamans", "Seely", "Seidel", "Selikoff", "Serrano", "Serventi", "Several", "Severino", "Shabalin", "Shakespear", "Shan", "Sharma", "She", "Shea", "Shen", "Shepard", "Sheperdigian", "Sherman", "Sherwood", "Shimshoni", "Shock", "Shoop", "Short", "Shridhar", "Silva", "Silverman", "Simmons", "Simon", "Simpson", "Sims", "Singer", "Singh", "Skelly", "Skjonaa", "Slattengren", "Slaven", "Sloan", "Smith", "Smith-Bates", "Sneath", "Snowden", "So", "Solanki", "Son", "Song", "Sotelo", "Sousa", "Spanaway", "Spencer", "Spicer", "Spoon", "Sreenivas", "Srini", "Srinivasan", "Stadick", "Stahl", "Stammler", "Stanev", "Stanley", "Steel", "Steele", "Steelman", "Steen", "Stefani", "Steiner", "Stenerson", "Stern", "Steuber", "Stevens", "Stewart", "Stiller", "Stone", "Storjohann", "Stotka", "Stotler", "Straatsma", "Strange", "Styles", "Su", "Suarez", "Subram", "Suess", "Suffin", "Sullivan", "Sultan", "Sun", "Sunkammurali", "Suri", "Sutton", "Suurs", "Svoboda", "Swaminathan", "Swan", "Swearengin", "Syamala", "Szymanski", "Taft-Rider", "Tallman", "Tamburello", "Tanara", "Tang", "Tangirala", "Tatman", "Taylor", "Teal", "Tedford", "Tejani", "Tench", "Teper", "Thakur", "Thames", "Theisen", "Thirunavukkarasu", "Thomas", "Thompson", "Thomsen", "Thoreson", "Thorpe", "Tian", "Tiano", "Tibbott", "Tiedt", "Ting", "Tippett", "Tomic", "Toone", "Torre", "Torres", "Townsend", "Track", "Tramel", "Tran", "Trau", "Traube", "Travers", "Trenary", "Trent", "Trolen", "Troyer", "Truempy", "Trujillo", "Tsoflias", "Tuell", "Tuffield", "Tullao", "Turner", "Uddin", "Uittenbogaard", "Umeda", "Underwood", "Uppal", "Vaca", "Valdez", "Valentine", "Valerio", "Valle", "Van", "Van Eaton", "Van Houten", "Vance", "Vande Velde", "Vandenouer", "Vanderbout", "Vanderhyde", "Vanderkamp", "Vanderlinden", "Vansant", "Vargas", "Varkey Chudukatil", "Vasquez", "Vazquez", "Velez Amezaga", "Venugopal", "Verboort", "Verdad", "Verhoff", "Vernon", "Veronesi", "Vessa", "Vicknair", "Vigil", "Villa", "Vincenzi", "Virden", "Visser", "Vlass", "Vong", "Vonholt", "Voss", "Vrettos", "Vrins", "Wadia", "Waggoner", "Wagner", "Waldal", "Walker", "Wall", "Walters", "Walton", "Wang", "Ward", "Ware", "Warthen", "Washington", "Watada", "Waters", "Watkins", "Watson", "Watters", "Watts", "Waxman", "Weadock", "Weber", "Wedge", "Weimer", "Weisman", "Welcker", "Weldon", "Wellington", "West", "Westbury", "Westguard", "Westover", "Wheeler", "Whipple", "White", "Whitehead", "Whiting", "Whitney", "Whitworth", "Wickham", "Wilcox", "Wilkie", "Willett", "Williams", "Wilson", "Winston", "Winter", "Wisnewski", "Wistrom", "Wojcik", "Wold", "Wolf", "Wollesen", "Wood", "Woodard", "Word", "Worden", "Wories", "Worland", "Wright", "Wruck", "Wu", "Wycoff", "Xie", "Xu", "Xylaras", "Yalovsky", "Yanagishima", "Yang", "Yasi", "Yasinski", "Ye", "Yee", "Yonekura", "Yong", "Young", "Youtsey", "Yu", "Yuan", "Yuhasz", "Yukish", "Yvkoff", "Zabokritski", "Zare", "Zeman", "Zeng", "Zhang", "Zhao", "Zheng", "Zhou", "Zhu", "Ziegler", "Zimmerman", "Zimprich", "Zubaty", "Zugelder", "Zukowski", "Zwilling" };
            
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();

            for (int i = 0; i < number; i++)
            {
                list.Add(new Tuple<string, string>(firstnames[Rand.Next(firstnames.Length)], lastnames[Rand.Next(lastnames.Length)]));
            }


            return list;
        }

        /// <summary>
        /// Returns the position of the first character that doesn't belong to the first name.
        /// </summary>
        static int FirstEnd(string s)
        {
            int count;
            for (count = 0; count < s.Length; count++)
            {
                if (s[count] == ' ' && s[count + 1] == ' ' && s[count + 2] == ' ')
                {
                    break;
                }
            }
            return count;
        }

        /// <summary>
        /// Returns the position of the first character that belongs to the last name.
        /// </summary>
        static int LastStart(int start, string s)
        {
            for (; start < s.Length; start++)
                if (s[start] != ' ')
                    break;
            return start;
        }
        /// <summary>
        /// Returns a monetary value as a decimal type (values have up to 2 fractional digits). The value may range from 0 to x.
        /// </summary>
        public decimal GetMoney(int lower=500, int upper=3000)
        {
            decimal lo = Math.Abs(lower);
            decimal up = Math.Abs(upper);
            return Math.Round((decimal)Rand.NextDouble() * (up-lo) + lo, 2);
        }

        /// <summary>
        /// Returns a date between the given dates (start and end inclusive).
        /// </summary>
        /// <param name="past"></param>
        /// <param name="future"></param>
        /// <returns></returns>
        public DateTime RandDate(DateTime past, DateTime future)
        {
            if (DateTime.Compare(past, future) > 0)
            {
                DateTime temp = past;
                past = future;
                future = temp;
            }
            int year = 0;
            try
            {
                year = Rand.Next(past.Year, future.Year + 1);
            }
            catch (Exception e)
            {
                throw e;
            }

            int minmonth = year == past.Year ? past.Month : 1;
            int maxmonth = year == future.Year ? future.Month : 12;
            int month = Rand.Next(minmonth, maxmonth + 1);

            int minday = (year == past.Year && month == past.Month) ? past.Day : 1;
            int maxday = (year == future.Year && month == future.Month) ? future.Day : DateTime.DaysInMonth(year, month);
            int day = Rand.Next(minday, maxday+1);

            return new DateTime(year, month, day);
        }

        /// <summary>
        /// Gets a valid chance (between 0 and 1) and returns if the event occurs.
        /// </summary>
        /// <param name="w">If w is negative, its absolute value will be taken into account. If it is greater than 1, it will be divided until it isn't.</param>
        /// <returns>True if the event occurs, otherwise false.</returns>
        public bool GetChance(double w = 0.5)
        {
            w = Math.Abs(w);
            while (w > 1.0)
            {
                w /= 10.0;
            }
            return Rand.NextDouble() > w ? false : true;
        }

    }
}