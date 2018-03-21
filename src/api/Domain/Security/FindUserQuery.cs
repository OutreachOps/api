namespace OutreachOperations.Api.Domain.Security
{
    public interface FindUserQuery
    {
        User Execute(string userName);
    }

    public interface FindUserQueryByEmail
    {
        User Execute(string emailAddress);
    }

}
