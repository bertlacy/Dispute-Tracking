function Set_ScheduleType(dropListScheduleTypesID, lblOccursID, panelWeekDaysID) 
{
    var dropListScheduleTypes = document.getElementById(dropListScheduleTypesID);
    var lblOccurs = document.getElementById(lblOccursID);
    var panelWeekDays = document.getElementById(panelWeekDaysID);

    switch (dropListScheduleTypes.options[dropListScheduleTypes.selectedIndex].value) 
    {
        case "1":  //Daily
            {
                lblOccurs.textContent = "Occurs Daily";
                panelWeekDays.style.display = "none";
                //$("#WeekDaysPanel").fadeIn(1000);
            } 
            break;
        case "2":  //Weekly
            {
                lblOccurs.textContent = "Occurs Weekly on every";
                panelWeekDays.style.display = "";
                //$("#WeekDaysPanel").fadeIn(1000);
            }
            break;
        case "3":  //Monthly
            {
                lblOccurs.textContent = "Occurs Monthly on every";
                panelWeekDays.style.display = "";
                //$("#WeekDaysPanel").fadeIn(1000);
            }
            break;
    }
}

function FadeIn(workingElementID, fadeTime) 
{
    var itemToFade = document.getElementById(workingElementID);
    $(itemToFade).delay(100).fadeIn(fadeTime);
}

function FadeOut(workingElementID, fadeTime) 
{
    var itemToFade = document.getElementById(workingElementID);
    $(itemToFade).delay(100).fadeOut(fadeTime);
}