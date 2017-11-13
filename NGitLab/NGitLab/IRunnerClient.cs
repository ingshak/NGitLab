﻿using System.Collections.Generic;
using NGitLab.Models;

namespace NGitLab
{
    /// <summary>
    /// Uses: https://github.com/gitlabhq/gitlabhq/blob/master/doc/api/runners.md
    /// </summary>
    public interface IRunnerClient
    {
        /// <summary>
        /// Get a list of projects accessible by the authenticated user.
        /// </summary>
        IEnumerable<Runner> Accessible { get; }
        
        /// <summary>
        /// Get a list of all GitLab projects (admin only).
        /// </summary>
        IEnumerable<Runner> All { get; }

        /// <summary>
        /// Get details of a runner
        /// </summary>
        Runner this[int id] { get; }

        /// <summary>
        /// Deletes the specified runner.
        /// </summary>
        void Delete(Runner runner);

        /// <summary>
        /// Deletes the specified runner.
        /// </summary>
        void Delete(int runnerId);

        /// <summary>
        /// Updates the tags, description, isActive
        /// </summary>
        /// <returns>The updated runner</returns>
        Runner Update(int runnerId, RunnerUpdate runnerUpdate);

        /// <summary>
        /// List all runners (specific and shared) available in the project. Shared runners are listed if at least one shared runner is defined and shared runners usage is enabled in the project's settings.
        /// </summary>
        /// <param name="projectId"></param>
        IEnumerable<Runner> GetAvailableRunners(int projectId);

        /// <summary>
        /// List all runners in the GitLab instance that meet the specified scope
        /// Admin privileges required
        /// </summary>
        /// <param name="scope"></param>
        IEnumerable<Runner> GetAllRunnersWithScope(Runner.Scope scope);

        /// <summary>
        /// Enable an available specific runner in the project.
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="runnerId"></param>
        Runner EnableRunner(int projectId, RunnerId runnerId);

        /// <summary>
        /// Disable a specific runner from the project. It works only if the project isn't the only project associated with the specified runner. If so, an error is returned. Use the Remove a runner call instead.
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="runnerId"></param>
        void DisableRunner(int projectId, RunnerId runnerId);
    }
}