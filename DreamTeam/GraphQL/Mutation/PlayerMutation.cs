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


                    

                });
             Field<CoachGraphType>("createCoach",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "name"},
                    new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "style"},
                    new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "experience"}

                ),
                resolve: tContext =>
                {

                    var name = tContext.GetArgument<string>("name");
                    var style = tContext.GetArgument<string>("style");
                    var experience= tContext.GetArgument<int>("experience");


                    var newCoach = new Coach()
                    {
                        Name = name,
                        Style = style,
                        Experience = experience

                    };
                    var coach = _service.AddCoach(newCoach);
                    return coach;
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