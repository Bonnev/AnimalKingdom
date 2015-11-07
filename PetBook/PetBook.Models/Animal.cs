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
            this.name = name;
            this.type = type;
            this.breed = breed;
            this.age = age;
            this.sex = sex;
            this.size = size;
            this.isAdopted = isAdopted;
            this.moreInformation = moreInformation;
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
