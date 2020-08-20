namespace provide.Model.Ident
{
    public class AuthResponse: BaseModel
    {
        public User User { get; set; } 
        public JWTToken Token { get; set; }    
    }
}