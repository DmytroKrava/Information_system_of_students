class Schedule:
    def __init__(self):
        self._groupsSchedule = []
        self._teachersSchedule = []

    def addScheduleGroup(self, groupSchedule):
        self._groupsSchedule.append(groupSchedule)

    def addScheduleTeacher(self, teacherSchedule):
        self._teachersSchedule.append(teacherSchedule)

    @property
    def groupsSchedule(self):
        return self._groupsSchedule.copy()


class ScheduleForGroup:
    def __init__(self, arg1, arg2):
        self._arg1 = arg1
        self._arg2 = arg2
    
    def __str__(self):
        return str(self._arg1) + str(self._arg2)


class ScheduleOnDay:
    def __init__(self, day):
        self._day = day
        self._subjectsList = []
    
    def addSubject(self, subject):
        self._subjectsList.append(subject)

    @property
    def day(self):
        return self._day
    
    @property
    def subjectList(self):
        return self._subjectsList.copy()


class Lesson:
    def __init__(self, name, time):
        self._name = name
        self._time = time

    @property
    def name(self):
        return self._name

    @property
    def time(self):
        return self._time
