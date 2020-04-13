export interface User {
  id: number;
  name: string;
  email: string;
  roomName: string;
  roomFloor: string;
  dormitoryName: string;
  dormitoryAddress: string;
  dormitoryId?: number;
  roomId?: number;
}
