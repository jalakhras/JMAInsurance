using System;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;

namespace JMAInsurance.Entity
{
    public class InsertUpdateInterceptor : IDbCommandTreeInterceptor
    {
        private readonly string _actionBy = "ModifiedById";
        private readonly string _actionDate = "ModifiedOn";
        private readonly string _createdDate = "CreatedOn";
        private readonly string _createdBy = "CreatedById";

        public void TreeCreated(DbCommandTreeInterceptionContext interceptionContext)
        {
            if (SessionManager.Current == null)
                return;
            
                if (interceptionContext.OriginalResult.DataSpace == DataSpace.SSpace)
                {
                    var insertCommand = interceptionContext.Result as DbInsertCommandTree;
                    if (insertCommand != null)
                    {
                        var now = DateTime.Now;


                        //var setClauses = insertCommand.SetClauses.Select(clause => clause.UpdateIfMatch(_createdDate, DbExpression.FromDateTime(now)))
                        //                                         .Select(clause => clause.UpdateIfMatch(_createdBy, DbExpression.FromInt32(SessionManager.Current.)))
                        //                              .ToList();

                        //var insert = new DbInsertCommandTree(
                        //            insertCommand.MetadataWorkspace,
                        //            insertCommand.DataSpace,
                        //            insertCommand.Target,
                        //            setClauses.AsReadOnly(),
                        //            insertCommand.Returning);

                        //interceptionContext.Result = insert;

                    }

                    var updateCommand = interceptionContext.Result as DbUpdateCommandTree;
                    //if (updateCommand != null)
                    //{
                    //    var now = DateTime.Now;

                    //    var setClauses = updateCommand.SetClauses.Select(clause => clause.UpdateIfMatch(_actionDate, DbExpression.FromDateTime(now)))
                    //                                             .Select(clause => clause.UpdateIfMatch(_actionBy, DbExpression.FromInt32(SessionManager.Current?.CurrentLoggedInUserWithNoDelegation?.UserId)))
                    //                                  .ToList();

                    //    var update = new DbUpdateCommandTree(
                    //           updateCommand.MetadataWorkspace,
                    //           updateCommand.DataSpace,
                    //           updateCommand.Target,
                    //           updateCommand.Predicate,
                    //           setClauses.AsReadOnly(),
                    //           null);

                    //    interceptionContext.Result = update;
                    //}
                }
        }
    }
}
