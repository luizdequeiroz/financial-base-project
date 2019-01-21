using System.ComponentModel;

namespace BaseProj.Api.Treatments.Enums
{
    public enum Suc
    {

        [Description("Cliente cadastrado com sucesso!")]
        ClientSuccessfullyRegistered = 1,

        [Description("Perfil atualizado com sucesso!")]
        ProfileUpdatedSuccessfully = 2,

        [Description("Perfil deletado com sucesso!")]
        ProfileDeletedSuccessfully = 3,

        [Description("Perfil atribuido com sucesso!")]
        SuccessfullyAssignedProfile = 4,

        [Description("Dados de inicialização inseridos com sucesso!")]
        InitializationDataEnteredSuccessfully = 5,

        [Description("Item de menu atualizado com sucesso!")]
        MenuItemUpdatedSuccessfully = 6,

        [Description("Item de menu deletado com sucesso!")]
        MenuItemDeletedSuccessfully = 7,

        [Description("Acesso a item de menu atribuido com sucesso!")]
        SuccessfullyAssignedMenuItem = 8,

        [Description("Sessão revalidada com sucesso!")]
        SessionRevalidatedSuccessfully = 9,

        [Description("Usuário cadastrado com sucesso!")]
        UserSuccessfullyRegistered = 10,

        [Description("Item de menu criado com sucesso!")]
        MenuItemSuccessfullyCreated = 11,

        [Description("Funcionário cadastrado com sucesso!")]
        EmployeeSuccessfullyRegistered = 12,

        [Description("Funcionário atualizado com sucesso!")]
        EmployeeUpdatedSuccessfully = 13,

        [Description("Funcionário deletado com sucesso!")]
        EmployeeDeletedSuccessfully = 14,

        [Description("Usuário deletado com sucesso!")]
        UserDeletedSuccessfully = 15,

        [Description("Sessão validada com sucesso!")]
        SessionValidatedSuccessfully = 16,

        [Description("Usuário atualizado com sucesso!")]
        UserUpdatedSuccessfully = 17,

        [Description("Um usuário encontrado!")]
        OneUserFound = 18,

        [Description("Cliente deletado com sucesso!")]
        ClientDeletedSuccessfully = 19,

        [Description("Cliente atualizado com sucesso!")]
        ClientUpdatedSuccessfully = 20,

        [Description("Um cliente encontrado!")]
        OneClientFound = 21
    }
}
