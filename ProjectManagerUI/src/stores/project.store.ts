import type { ProjectModel } from '@/models/project.model';
import { defineStore } from 'pinia'

export const useProjectStore = defineStore('projects', {
    state: () => ({ projects: [] as ProjectModel[] }),
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
        }
    }
  })