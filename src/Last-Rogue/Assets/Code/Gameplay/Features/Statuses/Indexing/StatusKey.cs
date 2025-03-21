namespace Code.Gameplay.Features.Statuses.Indexing
{
    public struct StatusKey
    {
        public readonly int TargetId;
        public readonly StatusTypeId StatusTypeId;

        public StatusKey(int targetId, StatusTypeId statusTypeId)
        {
            TargetId = targetId;
            StatusTypeId = statusTypeId;
        }
    }
}