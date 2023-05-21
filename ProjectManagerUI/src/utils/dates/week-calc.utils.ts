/**
 * Get the number of weeks between two given dates.
 * @param fromDate 
 * @param toDate 
 * @returns 
 */
export function calcWeeksBetweenTwoDatesUtil(fromDate: Date, toDate: Date) : number {
    let diff = Math.abs(fromDate.getTime() - toDate.getTime());
    let diffDays = Math.ceil(diff / (1000 * 3600 * 24)); 
    let diffWeeks = Math.ceil(diffDays / 7);

    return diffWeeks;
}

export function calcWeekNumberOfGivenDateBetweenARangeUtil(fromDate: Date, toDate: Date, givenDate: Date) {
    
    const weeks = calcWeeksBetweenTwoDatesUtil(fromDate, toDate);
    return (calcWeeksBetweenTwoDatesUtil(fromDate, givenDate)) % weeks;
}