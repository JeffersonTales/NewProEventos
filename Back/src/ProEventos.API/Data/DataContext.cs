using Microsoft.EntityFrameworkCore;
using ProEventos.API.Model;

namespace ProEventos.API.Data {
    public class DataContext : DbContext {

        /*/*O Entity Framework permite consultar, inserir, atualizar e excluir dados, usando objetos CLR(Common Language Runtime) conhecidos como entidades; 
         * ele mapeia as entidades e relacionamentos que são definidos no seu modelo de entidades para um banco de dados e fornece facilidades para realizar as seguintes tarefas:

        1- Materializar dados retornados do banco de dados como objetos de entidade;
        2- Controlar as alterações que foram feitas nos objetos;
        3- Lidar com concorrência;
        4- Propagar as alterações feitas nos objetos de volta ao banco de dados;
        5- Vincular objetos a controles.

        A principal classe responsável pela interação com os objetos de dados é a classe System.Data.Entity.DbContext (muitas vezes referida como o contexto).

        Essa classe de contexto administra os objetos entidades durante o tempo de execução, o que inclui preencher objetos com dados de um banco de dados, 
        controlar alterações, e persistir dados para o banco de dados.

        A maneira recomendada para trabalhar com o contexto é definir uma classe que deriva de DbContext e expõe as propriedades de DbSet que 
        representam as coleções das entidades especificadas no contexto.

        Essa classe é chamada de classe de contexto do banco de dados e coordena a funcionalidade do Entity Framework para um dado modelo de dados. 
        No código dessa classe você especifica quais entidades estão incluídas no modelo de dados. Você também pode personalizar determinado comportamento do Entity Framework.
        */

        public DataContext(DbContextOptions<DataContext> _options) : base(options: _options) {

        }

        /*Este código cria uma propriedade DbSet para cada conjunto de entidades. 
         * Na terminologia Entity Framework, um conjunto de entidades corresponde a uma tabela de banco de dados e uma entidade corresponde a uma linha na tabela.*/
        public DbSet<Evento> Eventos { get; set; }
        
    }
}
