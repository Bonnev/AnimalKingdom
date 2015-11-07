namespace PetBook.Models
{
    using Enums;

    public class Animal
    {
        private string name;
        private string type;
        private string breed;
        private uint age;
        private Sexes sex;
        private Sizes size;
        private bool isAdopted;
        private string moreInformation;

        public Animal(string name, string type, string breed, uint age, Sexes sex, Sizes size, bool isAdopted, string moreInformation)
        {
            this.Name = name;
            this.Type = type;
            this.Breed = breed;
            this.Age = age;
            this.Sex = sex;
            this.Size = size;
            this.IsAdopted = isAdopted;
            this.MoreInformation = moreInformation;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        public string Breed
        {
            get { return this.breed; }
            set { this.breed = value; }
        }
        public uint Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
        public Sexes Sex
        {
            get { return this.sex; }
            set { this.sex = value; }
        }
        public Sizes Size
        {
            get { return this.size; }
            set { this.size = value; }
        }
        public bool IsAdopted
        {
            get { return this.isAdopted; }
            set { this.isAdopted = value; }
        }
        public string MoreInformation
        {
            get { return this.moreInformation; }
            set { this.moreInformation = value; }
        }
    }
}
