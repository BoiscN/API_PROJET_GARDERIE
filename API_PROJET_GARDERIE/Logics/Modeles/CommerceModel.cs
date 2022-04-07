namespace API_PROJET_GARDERIE.Logics.Modeles
{
    public class CommerceModel
    {
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private string adresse;
        public string Adresse
        {
            get { return adresse; } 
            set { adresse = value; }
        }
        private string telephone;
        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }  
        }
        public CommerceModel()
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uneDescription"></param>
        /// <param name="uneAdresse"></param>
        /// <param name="unTelephone"></param>
        public CommerceModel(string uneDescription="",string uneAdresse="",string unTelephone = "")
        {
            description = uneDescription;
            adresse = uneAdresse;
            telephone = unTelephone;
        }
    }
}
