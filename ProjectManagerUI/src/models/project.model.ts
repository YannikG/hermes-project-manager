export interface ProjectModel {
    id: number | null;
    title: string;
    description: string;
    configWorkHoursPerDay: number;
    configWorkHoursPerWeek: number;
    projectStartDate: Date | null;
    projectEndDate: Date | null;
    timelineGroups: ProjectTimeLineGroupModel[];
}

export interface ProjectTimeLineGroupModel {
    id: number | null;
    title: string;
    description: string;
    sortRank: number;
    timelineItems: ProjectTimeLineItemModel[];
}

export interface ProjectTimeLineItemModel {
    id: number | null;
    title: string,
    description: string;
    startDateTime: Date;
    endDateTime: Date;
    status: number;
    type: number;
    sortRank: number;
}