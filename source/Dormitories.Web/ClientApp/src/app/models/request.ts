export interface StudentRequest {
  id: number;
  reason: string;
  itemId?: number;
  userId: number;
  requestType?: RequestTypes;
}

export interface StudentRequestWithUser {
  id: number;
  reason: string;
  itemId?: number;
  userId: number;
  requestType?: RequestTypes;
  userName: string;
  userEmail: string;
}

export enum RequestTypes {
  DormitoryComplain = 1,
  RoomComplain,
  ChangeDormitory,
  ChangeRoom,
}
