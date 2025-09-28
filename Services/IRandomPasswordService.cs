namespace LoginService.Services
{
    public interface IRandomPasswordService
    {
        public string GenerateRandomPassword(int lenght, bool upperCase, bool specialChar);

        public List<List<char>> GenerateCharArray();
    }
}
