export interface Group {
  id: number;
  title: string;
  startDate: Date;
  courseId: number;
  teacherId: number;
  teacherName: string;
  studingType: string;
  status: string;
  studentCapacity: number;
  courseTitle: string;
}

export interface GroupList {
  groups: Group[];
  groupsAmount: number;
}

export interface GroupFilter {
  groupStatus: string;
  courseTitle: string;
}
