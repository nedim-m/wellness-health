import 'package:fluent_ui/fluent_ui.dart';

class HomepageView extends StatefulWidget {
  const HomepageView({super.key});

  @override
  State<HomepageView> createState() => _HomepageViewState();
}

class _HomepageViewState extends State<HomepageView> {
  int topIndex = 0;
  PaneDisplayMode displayMode = PaneDisplayMode.top;

  List<NavigationPaneItem> items = [
    PaneItem(
      icon: const Icon(FluentIcons.people),
      title: const Text('Korsinici'),
      body: const Text("Home"),
    ),
    PaneItem(
      icon: const Icon(FluentIcons.teamwork),
      title: const Text('Zaposlenici'),
      body: const Text("Home1"),
    ),
    PaneItem(
      icon: const Icon(FluentIcons.temporary_user),
      title: const Text('Trenutno prisutni'),
      body: const Text("Home2"),
    ),
    PaneItem(
      icon: const Icon(FluentIcons.service_activity),
      title: const Text('Vrste usluge'),
      body: const Text("Home3"),
    ),
    PaneItem(
      icon: const Icon(FluentIcons.category_classification),
      title: const Text('Kategorije'),
      body: const Text("Home4"),
    ),
    PaneItem(
      icon: const Icon(FluentIcons.medical_care),
      title: const Text('Tretmani'),
      body: const Text("Home5"),
    ),
    PaneItem(
      icon: const Icon(FluentIcons.payment_card),
      title: const Text('Članarina'),
      body: const Text("Home6"),
    ),
    PaneItem(
      icon: const Icon(FluentIcons.leave_user),
      title: const Text('Odjava'),
      body: const Text("Home6"),
    ),
  ];

  @override
  Widget build(BuildContext context) {
    return NavigationView(
      appBar: const NavigationAppBar(
          title: Center(
              child: Text(
        "Wellness center Health",
        style: TextStyle(fontSize: 30),
      ))),
      pane: NavigationPane(
        selected: topIndex,
        onChanged: (index) => setState(() => topIndex = index),
        displayMode: displayMode,
        items: items,
      ),
    );
  }
}
