export interface ProjectModel {
    id: number | null;
    title: string;
    description: string;
    configWorkHoursPerDay: number;
    configWorkHoursPerWeek: number;
    projectStartDate: Date | null;
    projectEndDate: Date | null;
}