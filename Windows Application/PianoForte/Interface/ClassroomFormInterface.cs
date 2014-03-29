using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.View;
using PianoForte.Model;

namespace PianoForte.Interface
{
    interface ClassroomFormInterface
    {
        void load(MainForm mainForm, int roomNumber);

        void update(string currentTime);

        void updateTeacherImage(string currentTime);

        void updateTextBox_Status(string currentTime);
        
        void refreshRoomDetailList();
        
        void refreshClassroomDetailDictionary();

        Room getRoom();

        RoomDetail getRoomDetail(int index);

        List<RoomDetail> getRoomDetailList();

        List<ClassroomDetail> getClassroomDetailList(int teacherId);
    }
}
