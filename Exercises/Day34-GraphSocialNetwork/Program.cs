namespace SocialNetworking
{
    class Person
    {
        
        public string Name { get; set; }
        public List<Person> Friends = new List<Person>();
        public Person(string name)
        {
            Name = name;
        }
       
    }
    class socialNetwork
    {
        private List<Person> _members = new List<Person>();
        public void AddMember(Person member)
        {
            _members.Add(member);
        }
        public void AddFriend(Person p1, Person p2)
        {
            if (!(_members.Contains(p1) && (_members.Contains(p2))))
            {
                Console.WriteLine($"{p1.Name} and {p2.Name} not on network");
            }
            else
            {
                if (!p1.Friends.Contains(p2))
                {
                    p1.Friends.Add(p2);
                    p2.Friends.Add(p1);
                }
            }
        }
        public void ShowNetwork()
        {

            foreach (var mem in _members)
            {
                Console.Write(mem.Name + "->");
                List<string> friends = new List<string>();
                foreach (var i in mem.Friends)
                {
                    friends.Add(i.Name);
                }
                Console.WriteLine($"{string.Join(",", friends)}");
            }


        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            socialNetwork sn = new socialNetwork();
            Person a = new Person("Aman");
            Person b = new Person("Bhaskar");
            Person c = new Person("Chintu");
            Person d = new Person("Divakar");
            Person z = new Person("zinc");
            sn.AddMember(a);
            sn.AddMember(b);
            sn.AddMember(c);
            sn.AddMember(d);

            sn.AddFriend(a, b);
            sn.AddFriend(c, d);
            sn.AddFriend(c, a);
            sn.AddFriend(a, d);
            sn.AddFriend(a, a);
            sn.AddFriend(a, z);
            sn.AddFriend(a, d);



            sn.ShowNetwork();
        }
    }
}