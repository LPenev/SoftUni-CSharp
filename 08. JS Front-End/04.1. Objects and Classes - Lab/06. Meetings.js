function meetingPlaner(meetingsStringArray){
    //declare object meetings
    let meetings = {};
    convertStringArrayToObject(meetingsStringArray);
    printMeetings(meetings);
    
    function convertStringArrayToObject(meetingsStringArray){
        for(let currentMeet of meetingsStringArray){
            const [day, name] = currentMeet.split(' ');
            const isDayBusy = (meetings[day])?true:false;
            
            if(isDayBusy){
                printOutput(`Conflict on ${day}!`);
            }else{
                meetings[day] = name;
                printOutput(`Scheduled for ${day}`);
            }
        }
    }

    function printMeetings(meetings){
        for(const day in meetings){
            printOutput(`${day} -> ${meetings[day]}`);
        }
    }

    function printOutput(string){
        console.log(string);
    }

}

meetingPlaner(
    ['Friday Bob',
    'Saturday Ted',
    'Monday Bill',
    'Monday John',
    'Wednesday George']
    );