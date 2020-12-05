namespace Knjigovodstvo.Validators
{
    class DecimalValidate
    {
        public bool Check(string f)
        {
            f.Replace('.', ',');
            if (decimal.TryParse(f, out _))
            {
                return true;
            }
            return false;
        }
    }
}
