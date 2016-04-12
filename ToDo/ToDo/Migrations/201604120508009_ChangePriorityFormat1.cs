namespace ToDo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePriorityFormat1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TaskModels", "Priority", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TaskModels", "Priority", c => c.Int(nullable: false));
        }
    }
}
