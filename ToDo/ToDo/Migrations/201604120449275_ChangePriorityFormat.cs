namespace ToDo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePriorityFormat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TaskModels", "Priority", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TaskModels", "Priority", c => c.String());
        }
    }
}
