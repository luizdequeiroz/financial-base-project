using System.ComponentModel;

namespace BaseProj.Api.Treatments.Enums
{
    public enum Err
    {
        [Description("Usuário não existe!")]
        UserDoesNotExist = -1,

        [Description("Senha incorreta!")]
        WrongPassword = -2,

        [Description("Não há usuários!")]
        NoUsers = -3,

        [Description("Funcionário não existe!")]
        EmployeeDoesNotExist = -4,

        [Description("Usuário não pertence a nenhum setor!")]
        UserDoesNotBelongToAnyDepartment = -5,

        [Description("Usuário não possui permissão!")]
        UserDoesNotHavePermission = -6,

        [Description("Usuário ainda não possui acessos!")]
        UserDoesNotHaveAccessYet = -7,

        [Description("Não há clientes!")]
        NoClients = -8,

        [Description("Preenchimento inválido!")]
        InvalidPadding = -9,

        [Description("Não há perfis!")]
        NoProfiles = -10,

        [Description("Múltiplos erros!")]
        MultipleErrors = -11,

        [Description("Não há menus!")]
        NoMenus = -12,

        [Description("Usuário já existe!")]
        UserAlreadyExists = -13,

        [Description("Não há funcionários!")]
        NoEmployees = -14,

        [Description("Não há setores!")]
        NoDepartments = -15,

        [Description("Item de menu já existe!")]
        MenuItemAlreadyExists = -16,

        [Description("Funcionário já existe!")]
        EmployeeAlreadyExists = -17,

        [Description("Item de Menu não existe!")]
        MenuItemDoesNotExist = -18,

        [Description("Sessão não validada!")]
        SessionNotValidated = -19,

        [Description("Erro interno da operação!")]
        InternalOperationError = -20,

        [Description("Usuário(s) não encontrado(s)!")]
        UserNotFound = -21
    }
}
