﻿// Description: Entity Framework Bulk Operations & Utilities (EF Bulk SaveChanges, Insert, Update, Delete, Merge | LINQ Query Cache, Deferred, Filter, IncludeFilter, IncludeOptimize | Audit)
// Website & Documentation: https://github.com/zzzprojects/Entity-Framework-Plus
// Forum & Issues: https://github.com/zzzprojects/EntityFramework-Plus/issues
// License: https://github.com/zzzprojects/EntityFramework-Plus/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

#if EFCORE

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z.EntityFramework.Plus;

namespace Z.Test.EntityFramework.Plus
{
    public partial class QueryFilter_DbContext_SetFiltered
    {
        [TestMethod]
        public void WithGlobalManagerFilter_ManyFilter_Disable()
        {
            TestContext.DeleteAll(x => x.Inheritance_Interface_Entities);
            TestContext.Insert(x => x.Inheritance_Interface_Entities, 10);

            using (var ctx = new TestContext())
            {
                QueryFilterHelper.CreateGlobalManagerFilter(true, enableFilter1: false, enableFilter2: false, enableFilter3: false, enableFilter4: false);
                QueryFilterManager.InitilizeGlobalFilter(ctx);

                Assert.AreEqual(45, ctx.SetFiltered<Inheritance_Interface_Entity>().Sum(x => x.ColumnInt));

                QueryFilterHelper.ClearGlobalManagerFilter();
            }
        }
    }
}

#endif