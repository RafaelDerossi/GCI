namespace CondominioApp.BS.App.Model
{
    public class BalanceteAnaliticoModel
    {
        public int fileExists { get; private set; }
        public string link { get; private set; }

        public BalanceteAnaliticoModel(int fileExists, string link)
        {
            this.fileExists = fileExists;
            this.link = link;
        }
    }
}
