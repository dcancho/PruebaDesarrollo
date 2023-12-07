namespace PruebaDesarrollo.HumanResources.Domain.Models.Commands
{
    public record DeleteTrabajadorCommand
    {
        public int Id { get; init; }

        public DeleteTrabajadorCommand(int id)
        {
            Id = id;
        }
    }
}
