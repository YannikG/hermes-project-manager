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
                    this.projects.push(await response.json() as ProjectModel);
                })
                .catch(error => {
                    console.error(error);
                    error = error;
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
                    error = error;
            });
        },
        async addNewTimelineItemToGroup(groupId: number, timelineItem: ProjectTimeLineItemModel) {
            let request = {
                method: "POST",
                headers: new Headers({'content-type': 'application/json'}),
                body: JSON.stringify(timelineItem)
            };

            console.log(request.body);
            
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
                    error = error;
            });
        }
    }
})