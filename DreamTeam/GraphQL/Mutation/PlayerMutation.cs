using DreamTeam.Data.Models;
using DreamTeam.GraphQL.GraphTypes;
using DreamTeam.GraphQL.Services;
using GraphQL;
using GraphQL.Types;

namespace DreamTeam.GraphQL.Mutation
{
    public class PlayerMutation: ObjectGraphType
    {
        private readonly IPlayerService _service;
        
        public PlayerMutation(IPlayerService service)
        {
            _service = service;

            Field<PlayerGraphType>("createPlayer",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" },
                    new QueryArgument<NonNullGraphType<StringGraphType>>{Name = "number"},
                    new QueryArgument<NonNullGraphType<StringGraphType>>{Name = "height"}
                    
                ),
                resolve: tContext =>
                {
                    
                    var name = tContext.GetArgument<string>("name");
                    var number = tContext.GetArgument<string>("number");
                    var height=tContext.GetArgument<string>("height");
                   

                    var newPlayer = new Player()
                    {
                        Name =name,
                        Number= number,
                        Height=height
                       
                    };
                    var player = _service.AddPlayer(newPlayer);
                    return player;


                    //var newTeam = new Team(){ID = player.ID,
                    //WorkTeam = _service.CheckCoach(workTeam)};
                    //var team = _service.AddTeam(newTeam);


                    //return new Player()
                    //{ Name = name,Number = number, //Team=team};

                });
             Field<TeamGraphType>("createTeam",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "title"},
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "budget"},
                    new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "liga"}

                ),
                resolve: tContext =>
                {

                    var title = tContext.GetArgument<string>("title");
                    var budget = tContext.GetArgument<int>("budget");
                    var liga = tContext.GetArgument<string>("liga");


                    var newTeam = new Team()
                    {
                        Title = title,
                        Budget = budget,
                        Liga = liga

                    };
                    var team = _service.AddTeam(newTeam);
                    return team;
                });


            Field<PlayerGraphType>("updatePlayer",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>{Name = "id"},
                    new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "name"},//обновить имя вдруг была допущена ошибка
                    new QueryArgument<NonNullGraphType<StringGraphType>>{Name = "number"},//играет под другим номером
                    new QueryArgument<NonNullGraphType<StringGraphType>>{Name ="height"}//если игрок неожиданно вырос
                    ),
                resolve: tContext =>
                {
                    var id =int.Parse(tContext.GetArgument<string>("id"));
                    var name = tContext.GetArgument<string>("name");
                    var number = tContext.GetArgument<string>("number");
                    var height = tContext.GetArgument<string>("height");
                    var newPlayer = new Player()
                    {
                        Name = name,
                        Number = number,
                        Height = height
                    };
                    var player = _service.UpdatePlayer(newPlayer, id);

                    return player;
                }); 
            
            
            Field<PlayerGraphType>("deletePlayer",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>{Name = "id"}
                ),
                resolve: tContext =>
                {
                    var id =int.Parse(tContext.GetArgument<string>("id"));
                    
                    var player = _service.DeletePlayer(id);

                    return player;
                }); 
        }
    }
}