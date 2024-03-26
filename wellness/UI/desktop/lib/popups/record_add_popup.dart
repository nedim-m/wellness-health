import 'package:flutter/material.dart';

import '../models/search_result.dart';
import '../models/user.dart';
import '../providers/record_provider.dart';
import '../providers/user_provider.dart';
import '../utils/validation_rules.dart';

class RecordAddPopupWidget extends StatefulWidget {
  final Function() refreshCallback;

  const RecordAddPopupWidget({super.key, required this.refreshCallback});

  @override
  State<RecordAddPopupWidget> createState() => _RecordAddPopupWidgetState();
}

class _RecordAddPopupWidgetState extends State<RecordAddPopupWidget> {
  final UserProvider userProvider = UserProvider();
  final RecordProvider recordProvider = RecordProvider();
  SearchResult<User> myData = SearchResult<User>();
  User? selectedUser;
  List<User> allUsers = [];
  final _formKey = GlobalKey<FormState>();
  final _validation = ValidationRules();

  Future<void> fetchData() async {
    myData = await userProvider.get(filter: {'prisutan': 'NE'});
    setState(() {
      allUsers = myData.result;
    });
  }

  @override
  void initState() {
    fetchData();
    super.initState();
  }

  void _saveChanges() async {
    if (_formKey.currentState!.validate()) {
      await recordProvider.addEntry(selectedUser!);
      widget.refreshCallback();
      // ignore: use_build_context_synchronously
      Navigator.of(context).pop();
    }
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      backgroundColor: Colors.white,
      title: const Text("Evidentiraj ulazak"),
      content: Form(
        key: _formKey,
        child: Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            DropdownButtonFormField<User>(
              value: selectedUser,
              onChanged: (newValue) {
                setState(() {
                  selectedUser = newValue;
                });
              },
              items: allUsers.map<DropdownMenuItem<User>>((User user) {
                return DropdownMenuItem<User>(
                  value: user,
                  child: Text("${user.firstName} ${user.lastName}"),
                );
              }).toList(),
              hint: const Text("Izaberite korisnika"),
              validator: _validation.validateDropdown,
            ),
          ],
        ),
      ),
      actions: [
        TextButton(
          onPressed: _saveChanges,
          child: const Text("Spremi"),
        ),
        TextButton(
          onPressed: () {
            Navigator.of(context).pop();
          },
          child: const Text("Otkaži"),
        ),
      ],
    );
  }
}
