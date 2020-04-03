import { Dormitory } from "./dormitory";
import { Room } from "./room";

export interface Student {
  id: number;
  name: string;
  email: string;
  dormitory: Dormitory;
  dormitoryId: number;
  room: Room;
  roomId: number;
}
