namespace Possibilities
{
    [System.Serializable]
    public class PlayerAttributes
    {
        public Attributes Attribute;
        public int Amount;

        public PlayerAttributes(Attributes attribute, int amount)
        {
            this.Attribute = attribute;
            this.Amount = amount;
        }
    }
}
