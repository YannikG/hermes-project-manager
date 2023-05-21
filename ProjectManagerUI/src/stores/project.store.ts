import type { ProjectModel, ProjectTimeLineGroupModel, ProjectTimeLineItemModel } from '@/models/project.model';
import { defineStore } from 'pinia'

export const useProjectStore = defineStore('projects', {
    state: () => ({ projects: [] as ProjectModel[] }),
    getters: {
        getProjects(state) {
            return state.projects;
        },
        getProjectById: (state) => (id: number) => {
            return state.projects.find(p => p.id == id);
        }
    },
    actions: {
        async loadProjects() {
            await fetch("/api/projects")
                .then(async response => {
                    this.projects = await response.json() as ProjectModel[];
                })
        },
        async addNewProject(project: ProjectModel) {
            let request = {
                method: "POST",
                // don't forget the fucking HEADERS!
                headers: new Headers({'content-type': 'application/json'}),
                body: JSON.stringify(project)
            };

            await fetch("/api/projects", request)
                .then(async response => {
                    let backendResponse = await response.json() as ProjectModel;
                    backendResponse.timelineGroups = [];
                    this.projects.push(backendResponse);
                })
                .catch(error => {
                    console.error(error);
            });
        },
        async deleteProject(projectId: number) {
            let request = {
                method: "DELETE"
            };

            await fetch(`/api/projects/${projectId}`, request)
                .then(async _ => {
                    this.projects = this.projects.filter(p => p.id != projectId);
                })
                .catch(error => {
                    console.error(error);
                });  
        },

        async addNewGroupToProject(projectId: number, group: ProjectTimeLineGroupModel) {

            let request = {
                method: "POST",
                headers: new Headers({'content-type': 'application/json'}),
                body: JSON.stringify(group)
            };

            await fetch(`/api/projects/${projectId}/timelineGroups`, request)
                .then(async response => {
                    this.projects.find(p => p.id == projectId)?.timelineGroups.push(await response.json() as ProjectTimeLineGroupModel);
                })
                .catch(error => {
                    console.error(error);
            });
        },

        async deleteGroupFromProject(projectId: number, timelineGroup: ProjectTimeLineGroupModel) {
            let request = {
                method: "DELETE"
            };

            await fetch(`/api/projects/${projectId}/timelineGroups/${timelineGroup.id}`, request)
                .then(async _ => {
                    this.projects
                        .find(p => p.id == projectId)!.timelineGroups = this.projects
                            .find(p => p.id == projectId)!.timelineGroups
                                .filter(g => g.id != timelineGroup.id) as ProjectTimeLineGroupModel[];
                })
                .catch(error => {
                    console.error(error);
                });
        },

        async addNewTimelineItemToGroup(groupId: number, timelineItem: ProjectTimeLineItemModel) {
            let request = {
                method: "POST",
                headers: new Headers({'content-type': 'application/json'}),
                body: JSON.stringify(timelineItem)
            };
            
            await fetch(`/api/projects/timelineGroups/${groupId}/timelineItems`, request)
                .then(async response => {
                    this.projects
                        .find(p => p.timelineGroups
                            .find(g => g.id == groupId)
                        )
                        ?.timelineGroups.find(g => g.id == groupId)
                            ?.timelineItems.push(await response.json() as ProjectTimeLineItemModel);
                })
                .catch(error => {
                    console.error(error);
            });
        },

        async deleteTimelineItemFromGroup(projectId: number, timelineItem: ProjectTimeLineItemModel) {
            let request = {
                method: "DELETE"
            };

            await fetch(`/api/projects/timelineGroups/${timelineItem.timelineGroupId}/timelineItems/${timelineItem.id}`, request)
                .then(async _ => {
                    this.projects
                        .find(p => p.id == projectId)!.timelineGroups
                            .find(g => g.id == timelineItem.timelineGroupId)!.timelineItems = this.projects
                                .find(p => p.id == projectId)!.timelineGroups
                                    .find(g => g.id == timelineItem.timelineGroupId)!.timelineItems
                                        .filter(i => i.id != timelineItem.id) as ProjectTimeLineItemModel[];
                })
                .catch(error => {
                    console.error(error);
                });
        }
    }
})