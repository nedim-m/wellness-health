import 'package:flutter/material.dart';

import '../models/search_result.dart';
import '../models/user.dart';
import '../providers/user_provider.dart';

class RecordAddPopupWidget extends StatefulWidget {
  const RecordAddPopupWidget({super.key});

  @override
  State<RecordAddPopupWidget> createState() => _RecordAddPopupWidgetState();
}

class _RecordAddPopupWidgetState extends State<RecordAddPopupWidget> {
  final UserProvider userProvider = UserProvider();
  SearchResult<User> myData = SearchResult<User>();
  User? selectedUser;
  List<User> allUsers = [];

  Future<void> fetchData() async {
    myData = await userProvider.get(filter: {'prisutni': 'NE'});
    setState(() {
      allUsers = myData.result;
    });
  }

  @override
  void initState() {
    fetchData();
    super.initState();
  }

  void _saveChanges() async {}

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: const Text("Evidentiraj ulazak"),
      content: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          DropdownButton<User>(
            value: selectedUser,
            onChanged: (newValue) {
              setState(() {
                selectedUser = newValue!;
              });
            },
            items: allUsers.map<DropdownMenuItem<User>>((User user) {
              return DropdownMenuItem<User>(
                value: user,
                child: Text("${user.firstName} ${user.lastName}"),
              );
            }).toList(),
            hint: const Text("Izaberite korisnika"),
          ),
        ],
      ),
      actions: [
        TextButton(
          onPressed: _saveChanges,
          child: const Text("Save"),
        ),
        TextButton(
          onPressed: () {
            Navigator.of(context).pop();
          },
          child: const Text("Cancel"),
        ),
      ],
    );
  }
}
