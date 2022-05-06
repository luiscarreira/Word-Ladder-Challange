namespace WordLadderBusiness.Contracts
{
    public interface IWordLadderRunner
    {
        /// <summary>
        /// Run the Word Ladder Async
        /// </summary>
        /// <param name="solver">The service that will solve the Word Ladder</param>
        /// <param name="startString">The start string for the Word Ladder</param>
        /// <param name="endString">The end string for the Word Ladder</param>
        /// <param name="token">The CancelationToken</param>
        /// <returns></returns>
        public Task RunAsync(IWordLadderSolver solver, string startString, string endString, CancellationToken token);

        /// <summary>
        /// Run the Word Ladder Async
        /// </summary>
        /// <param name="solver">The service that will solve the Word Ladder</param>
        /// <param name="startString">The start string for the Word Ladder</param>
        /// <param name="endString">The end string for the Word Ladder</param>
        /// <param name="maxWordLenghtAllowed">the max lenght allowed for words</param>
        /// <param name="token">The CancelationToken</param>
        /// <returns></returns>
        public Task RunAsync(IWordLadderSolver solver, string startString, string endString, int maxWordLenghtAllowed, CancellationToken token);
    }
}
