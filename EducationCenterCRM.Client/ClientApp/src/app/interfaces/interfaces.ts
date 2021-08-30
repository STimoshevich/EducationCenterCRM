export interface Course {
  id: number;
  title: string;
  description: string;
  program: string;
  topicId: number;
  imageUrl: string;
  topic: Topic;
}

export interface Topic {
  id: number;
  title: string;
  description: string;
}
